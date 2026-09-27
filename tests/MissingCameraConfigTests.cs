using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
class Check {
[STAThread] static void Main(string[] args) {
var asm=Assembly.LoadFrom(Path.GetFullPath(args[0]));
var ini=asm.GetType("SC6000DualMonitor.IniConfig");
var formType=asm.GetType("SC6000DualMonitor.MonitorForm");
string path=Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"config.ini");
foreach(var text in new[]{"CAMERAS=2\n[CAMERA1]\nIP=192.0.2.10\n", "CAMERAS=2\n[CAMERA1]\nIP=   \n"}) {
File.WriteAllText(path,text);
var config=ini.GetMethod("Load").Invoke(null,new object[]{path});
var cam=ini.GetMethod("GetCamera").Invoke(config,new object[]{2});
if((string)cam.GetType().GetProperty("Ip").GetValue(cam,null)!="") throw new Exception("Missing camera must be empty");
using(var form=(Form)Activator.CreateInstance(formType,new object[]{config,Path.GetFullPath(args[0]),Path.GetDirectoryName(Path.GetFullPath(args[0]))})) {
var flags=BindingFlags.NonPublic|BindingFlags.Instance;
var states=(IList)formType.GetField("_configured",flags).GetValue(form);
if(states.Count!=2 || (bool)states[1]) throw new Exception("Slot mapping failure");
var labels=(IList)formType.GetField("_statuses",flags).GetValue(form);
var pane = ((Label)labels[1]).Parent.Parent.Parent;
if(pane.GetType().Name!="SolutionPane") throw new Exception("Missing solution controls for unconfigured camera");
foreach(string field in new[]{"_choices", "_refresh", "_change"}) {
var control=(Control)pane.GetType().GetField(field,flags).GetValue(pane);
if(control.Enabled) throw new Exception("Disconnected solution control must be disabled");
}
if(!((Label)labels[1]).Text.Contains("IP 미설정")) throw new Exception("Missing inline guidance");
if(!(bool)states[0]) {
formType.GetMethod("StartViewers",flags).Invoke(form,null);
var viewers=(IList)formType.GetField("_viewers",flags).GetValue(form);
if(viewers.Count!=2 || viewers[0]!=null || viewers[1]!=null) throw new Exception("Unconfigured process launched");
((Timer)formType.GetField("_watch",flags).GetValue(form)).Stop();
}
}
}
Console.WriteLine("PASS: missing CAMERA2, blank IPs, main form construction, inline status, unconfigured viewer suppression and slot mapping");
}
}

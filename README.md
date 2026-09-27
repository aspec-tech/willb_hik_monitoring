# WILLB SC6000 Monitor

VisionMaster 4.4.x SDK와 .NET Framework 4.6.1 개발 도구가 설치된 Visual Studio에서 `SC6000_Dual_OperationInterface.sln`을 열어 빌드합니다.

- 저장소는 어느 폴더에 복제해도 됩니다. 최초 빌드 시 `SC6000DualMonitor/config.ini`가 없으면 `config.example.ini`에서 자동 생성합니다. 기존 설정은 덮어쓰지 않습니다.
- 생성된 `config.ini`의 카메라 IP와 비밀번호 등을 실제 장비에 맞게 설정하고 다시 빌드하세요. 예제 IP는 실제 장비 주소가 아닙니다.
- 프로그램은 작업 디렉터리와 관계없이 실행 파일 옆의 `config.ini`를 읽습니다. 배포할 때는 `bin/Release`의 전체 내용을 함께 복사하고, 대상 PC에도 VisionMaster 런타임을 설치하세요.
- 배포 폴더의 `config.ini`를 직접 수정한 경우 해당 파일을 별도로 보관하세요. 소스 설정을 수정하고 다시 빌드하면 출력 폴더의 설정이 갱신될 수 있습니다.
- WILLB 로고는 `SC6000DualMonitor/Assets/willb.png`에서 실행 파일에 내장되므로 별도 로고 파일이나 원본 이미지 경로가 필요하지 않습니다.
- 실제 장비 설정, 공급업체 바이너리, 로그 및 빌드 결과는 Git에서 제외됩니다.

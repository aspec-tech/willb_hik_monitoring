# WILLB SC6000 Monitor

VisionMaster 4.4.x SDK와 .NET Framework 4.6.1 개발 도구가 설치된 Visual Studio에서 `SC6000_Dual_OperationInterface.sln`을 열어 빌드합니다.

- 저장소는 어느 폴더에 복제해도 됩니다. 최초 빌드 시 `SC6000DualMonitor/config.ini`가 없으면 `config.example.ini`에서 자동 생성합니다. 기존 설정은 덮어쓰지 않습니다.
- 생성된 `config.ini`의 카메라 IP와 비밀번호 등을 실제 장비에 맞게 설정하고 다시 빌드하세요. 예제 IP는 실제 장비 주소가 아닙니다.
- 프로그램은 작업 디렉터리와 관계없이 실행 파일 옆의 `config.ini`를 읽습니다. 배포할 때는 `bin/Release`의 전체 내용을 함께 복사하고, 대상 PC에도 VisionMaster 런타임을 설치하세요.
- 배포 폴더의 `config.ini`를 직접 수정한 경우 해당 파일을 별도로 보관하세요. 소스 설정을 수정하고 다시 빌드하면 출력 폴더의 설정이 갱신될 수 있습니다.
- WILLB 로고는 `SC6000DualMonitor/Assets/willb.png`에서 실행 파일에 내장되므로 별도 로고 파일이나 원본 이미지 경로가 필요하지 않습니다.
- 실제 장비 설정, 공급업체 바이너리, 로그 및 빌드 결과는 Git에서 제외됩니다.

## 시작 Solution 자동 로딩

각 `[CAMERA1]` ~ `[CAMERA4]` 구역에 아래 설정을 추가하세요. 기존 `config.ini`는 보존되므로 새 항목은 직접 추가해야 합니다.

```ini
[CAMERA1]
IP=192.0.2.10
PASSWORD=
TITLE=Camera 1
SOLUTION_PATH=/root/vmtempfiles/ftp/solution/검사.solx
SOLUTION_PASSWORD=
SOLUTION_DIRECTORY=
```

`SOLUTION_PATH`는 실제 카메라 내부 파일의 전체 경로로 바꾸세요. PC의 파일 경로가 아닙니다. 카메라 접속 직후 해당 Solution을 로딩하고 Operation Interface를 표시합니다. `SOLUTION_PASSWORD`는 Solution 파일 비밀번호이며 접속 비밀번호 `PASSWORD`와 구분됩니다. 경로가 비어 있거나 항목이 없으면 기존처럼 카메라의 현재 Solution을 표시합니다. 로딩 실패 시 카메라와 실패 단계, 지정 경로를 표시하고 화면 로딩을 중단합니다.

소스 폴더의 `config.ini`를 수정했다면 다시 빌드하세요. 실행 파일 옆의 설정을 수정했다면 프로그램을 다시 실행하세요.

## Visual Studio 시작 항목

폴더 열기 대신 `파일 → 열기 → 프로젝트/솔루션`에서 `SC6000_Dual_OperationInterface.sln`을 여세요. 이 솔루션에는 실행 프로젝트 `SC6000DualMonitor` 하나만 있습니다. 폴더 모드에서 `.sln`과 `.csproj`가 시작 후보로 함께 표시되어도 실행 프로그램이 두 개 생긴 것은 아닙니다. 필요하면 솔루션 탐색기에서 `SC6000DualMonitor`를 우클릭해 시작 프로젝트로 설정하세요.

카메라 IP가 누락되거나 비어 있어도 메인 화면은 실행됩니다. 해당 카메라 영역에 설정 안내를 표시하고 연결을 건너뜁니다. 다른 카메라는 정상적으로 연결하며, 연결 실패도 해당 영역에 표시합니다.


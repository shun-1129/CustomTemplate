@echo off

@REM CustomWorkerServiceコピー
set FROM_CUSTOM_WORKER_SERVICE=.\WorkerServiceTemplate.zip

@REM ここにコピー
set TO_PATH=%USERPROFILE%\Documents\"Visual Studio 2022"\Templates\ProjectTemplates\

copy /y %FROM_CUSTOM_WORKER_SERVICE% %TO_PATH%

timeout /t 60
exit /b
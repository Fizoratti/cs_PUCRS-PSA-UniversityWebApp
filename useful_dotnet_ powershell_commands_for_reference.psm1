$currentPwd = [System.IO.Path]::GetDirectoryName($MyInvocation.MyCommand.Source);

function GoToMatrix {
    Set-Location $currentPwd;
}

function GoToMatrixWeb {
    Set-Location $currentPwd\src\web\Dell.Matrix;
}

function GoToMatrixData {
    Set-Location $currentPwd\src\web\Dell.Matrix\src\Dell.Matrix.Data;
}

function GoToMatrixChatbot {
    Set-Location $currentPwd\src\smart\chatbot;
}

function MatrixCleanModelAndTrainChatbot {
    GoToMatrixChatbot;
    .\venv\Scripts\activate
    rm .\models\*.gz | rasa train -vv;
}

function InstallMatrixWebClientDepedencies {
    $currentLocation = Get-Location;
    GoToMatrixWebClient;
    npm i;
    Set-Location $currentLocation.Path;
}

function InstallMatrixWebDepedencies {    
    $currentLocation = Get-Location;  
    GoToMatrixWeb;
    dotnet restore;
    Set-Location $currentLocation.Path;
}

function MatrixUpdateDatabase {
    $currentLocation = Get-Location;    
    GoToMatrixData;   
    dotnet ef database update --startup-project ..\Dell.Matrix.Web\Dell.Matrix.Web.csproj;
    Set-Location $currentLocation.Path;
}

function MatrixCoverage {
    Set-Location $currentPwd\src\web\Dell.Matrix;
    .\build.ps1 -Target Coverage
}

function MatrixE2E {
    Set-Location $currentPwd\src\web\Dell.Matrix;
    .\build.ps1 -Target End2EndTests
}

function MatrixKillChromeDriver {
    Set-Location $currentPwd\src\web\Dell.Matrix;
    .\build.ps1 -Target CleanUpChromeProcess
}

function GoToMatrixMobile {
    Set-Location $currentPwd\src\mobile\dell_matrix;
}

function GoToMatrixSmart {
    Set-Location $currentPwd\src\smart\dell_matrix;
}


function GoToMatrixTests {
    Set-Location $currentPwd\src\web\Dell.Matrix\tests;
}


function MobileCoverage {
    GoToMatrixMobile;
    .\build.ps1 -Target Coverage
}

function RunAllTests {
    Write-Host "Iniciando testes de backend" -ForegroundColor Green;
    MatrixCoverage
    Write-Host "Iniciando testes de mobile" -ForegroundColor Green;
    MobileCoverage
    Write-Host "Iniciando testes E2E" -ForegroundColor Green;
    MatrixE2E
}

function FlutterWatchBuildRunner {
    Set-Location $currentPwd\src\mobile\dell_matrix;
    flutter pub run build_runner watch --delete-conflicting-outputs
}

function CleanLocalBranchesThatWereGone {
    git branch -vv | Select-String -Pattern ".+\s+\w+\s\[origin\/([\w\/-]+):\sgone\]" | ForEach-Object { git branch -D $_.Matches[0].Groups.Value }
}

function RunMatrixWeb {
    invoke-expression 'cmd /c start pwsh -Command RunServiceFileSystem'
    GoToMatrixWeb
    Set-Location .\src\Dell.Matrix.Web\
    dotnet watch run --urls http://0.0.0.0:5000
}

function RunServiceFileSystem {
    GoToMatrixWeb;
    Set-Location .\src\Dell.Matrix.ServiceFileSystem\;
    dotnet watch run --urls http://0.0.0.0:5010;
}

function RunMatrixWorkerService {
    GoToMatrixWorkerService
    dotnet build
    dotnet watch run --urls http://0.0.0.0:5002
}
function DropMatrixDb {
    $currentLocation = Get-Location;
    GoToMatrixData;
    dotnet ef database drop -f --no-build --startup-project ..\Dell.Matrix.Web\Dell.Matrix.Web.csproj;
    Set-Location $currentLocation.Path
}

function AddNewMigration($migrationName, $updateDb) {
    $currentLocation = Get-Location;
    Set-Location $currentPwd\src\web\Dell.Matrix\src\Dell.Matrix.Data\;
    dotnet ef database drop -f --no-build --startup-project ..\Dell.Matrix.Web\Dell.Matrix.Web.csproj;
    dotnet ef migrations add $migrationName --startup-project ..\Dell.Matrix.Web\Dell.Matrix.Web.csproj;
    if ($updateDb -eq $true) {
        dotnet ef database update --no-build --startup-project ..\Dell.Matrix.Web\Dell.Matrix.Web.csproj;
    }
    Set-Location $currentLocation.Path
}

function RemoveLastAppliedMigration() {
    DropMatrixDb;
    $currentLocation = Get-Location;
    GoToMatrixData;
    dotnet ef migrations remove -f --no-build --startup-project ..\Dell.Matrix.Web\Dell.Matrix.Web.csproj;
    Set-Location $currentLocation.Path;
}

function GoToMatrixWorkerService {
    Set-Location $currentPwd\src\web\Dell.Matrix\src\Dell.Matrix.WorkerService\;
}

function GoToMatrixWebClient {
    Set-Location $currentPwd\src\web\Dell.Matrix\src\Dell.Matrix.Web\ClientApp;
}

function BuildAndroidForUAT {
    GoToMatrixMobile;
    flutter pub get;
    flutter build apk --flavor uat -t lib/main_uat.dart
}

function BuildAndroidForPROD {
    GoToMatrixMobile;
    flutter pub get;
    flutter build apk --flavor prod -t lib/main_prod.dart
}

function RunMatrixAndroid {
    GoToMatrixMobile;
    flutter pub get;
    flutter run 
}

function RunMatrixUAT {
    GoToMatrixMobile;
    flutter pub get;
    flutter run --flavor uat -t lib/main_uat.dart
}

function MatrixWhatsMyApkVersion($apkPath) {
    GoToMatrixMobile;
    Set-Location .\tools;
    $newApkVersions = .\aapt.exe dump badging $apkPath | Where-Object { $_ -match "VersionName" };
    ForEach-Object -Process { $newApkVersions -match "(versionCode=')(.*?)'" } | Out-Null;
    Write-Host "O versionCode do seu apk é: $($Matches[2])";
    ForEach-Object -Process { $newApkVersions -match "(versionName=')(.*?)'" } | Out-Null;
    Write-Host "O versionName do seu apk é: $($Matches[2])";
}

function st() {
    git status;
}

function co([parameter(position = 1)]$branch) {
    git checkout $branch;
}

function sendf() {
    git push origin HEAD -u --force-with-lease;
}
function updateMaster() {
    git checkout master;
    git pull --rebase --prune;
}

function fazRebase {
    $currentBranch = git rev-parse --abbrev-ref HEAD;
    Write-Host "Indo para development" -ForegroundColor Green;
    git checkout development;
    Write-Host "Fazendo pull rebase" -ForegroundColor Green;
    git pull --rebase --prune;
    Write-Host "Voltando para $currentBranch" -ForegroundColor Green;
    git checkout $currentBranch;
    Write-Host "Fazendo rebase" -ForegroundColor Green;
    git rebase development;
}

function ammend {
    git add .
    git commit --amend --no-edit
}

function renameBranch($nameName) {
    git branch -m  $nameName
}


function GoToMatrixWebWeb {

    Set-Location $currentPwd\src\web\Dell.Matrix\src\Dell.Matrix.Web;

}

function FlutterEmulator {

    GoToMatrixMobile;

    flutter emulator --launch Pixel_3a;

}

function FlutterRun {

    GoToMatrixMobile;

    flutter run --flavor dev -t .\lib\main.dart

}

function DotnetRun {

    GoToMatrixWebWeb;

    dotnet run

}
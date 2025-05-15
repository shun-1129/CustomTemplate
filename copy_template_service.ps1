param (
    [string]$NewSolutionName
)

if (-not $NewSolutionName) {
    $NewSolutionName = Read-Host "引数が指定されていません。入力してください"
}

$BaseSolutionFileName = "TestSolution.sln"
$OldSolutionName = "WorkerServiceTemplate"
# コピー元とコピー先のパス
$source = ".\$OldSolutionName"
$destination = ".\$NewSolutionName"

# フォルダを再帰的にコピー（サブフォルダやファイルも含めて）
Copy-Item -Path $source -Destination $destination -Recurse

# 移動
Set-Location ".\$NewSolutionName"
# .vsを削除
Remove-Item -Path ".vs" -Recurse -Force

# 名称変更
Rename-Item -Path ".\$OldSolutionName" -NewName ".\$NewSolutionName"
Rename-Item -Path ".\$OldSolutionName.sln" -NewName ".\$NewSolutionName.sln"

$filePath = ".\$NewSolutionName.sln"
(Get-Content $filePath -Raw) -replace $OldSolutionName, $NewSolutionName | Set-Content $filePath

# 移動
Set-Location ".\$NewSolutionName"

# objを削除
if (Test-Path "obj") {
    Remove-Item -Path "obj" -Recurse -Force
}
# binを削除
if (Test-Path "bin") {
    Remove-Item -Path "bin" -Recurse -Force
}

# 名称変更
Rename-Item -Path ".\$OldSolutionName.csproj" -NewName ".\$NewSolutionName.csproj"

$filePath = ".\$NewSolutionName.csproj"
(Get-Content $filePath -Raw) -replace $OldSolutionName, $NewSolutionName | Set-Content $filePath

# 指定フォルダ（例: .\）にあるすべての .cs ファイルを再帰的に取得
$folderPath = ".\"
$csFiles = Get-ChildItem -Path $folderPath -Recurse -Filter *.cs -File

foreach ($file in $csFiles) {
    $filePath = $($file.FullName)
    (Get-Content $filePath -Raw) -replace $OldSolutionName, $NewSolutionName | Set-Content $filePath
}

Set-Location ../
Set-Location ../
$CsprojFilePath = $(Get-Location)
# Solutionに追加
dotnet sln ".\$BaseSolutionFileName" add "$CsprojFilePath\$NewSolutionName\$NewSolutionName\$NewSolutionName.csproj"

Write-Host "60秒待機します。キーを押すと終了します..."

$timeout = 60  # 秒
$interval = 100  # チェック間隔（ミリ秒）
$elapsed = 0

while ($elapsed -lt ($timeout * 1000)) {
    Start-Sleep -Milliseconds $interval
    $elapsed += $interval

    if ([System.Console]::KeyAvailable) {
        # キーを読み取ってバッファをクリア（Enter を押さなくてもよい）
        [System.Console]::ReadKey($true) > $null
        break
    }
}
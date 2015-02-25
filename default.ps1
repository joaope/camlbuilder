properties {
    $global:configuration = 'Debug'
    $bin_folder = 'CAMLBuilder\bin'
}

task default -depends compile
task debug -depends default
task release -depends set_release, default
task dist -depends release {
    'Do the nuget thing!'
}

task clean {
    'Clean!'
}

task compile -depends clean {
    exec { msbuild /t:Clean /t:Build /nologo /p:Configuration=$configuration "CAMLBuilder.sln" }
}

task test -depends compile { 
    'Run tests!'
}

task set_release {
    $global:configuration = 'Release'
}

task ? {
    Write-Documentation
}
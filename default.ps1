properties {
    $global:configuration = "debug"
    
	$base_folder = Resolve-Path .
    $source_folder = "$base_folder\src"
    $output_folder = "$base_folder\out"
}

task default -depends compile

task clean {
    rd "$source_folder\artifacts" -recurse -force  -ErrorAction SilentlyContinue | out-null
	rd "$output_folder" -recurse -force  -ErrorAction SilentlyContinue | out-null
}

task compile -depends clean {
	exec { dnu restore }
    exec { dnu build $source_folder\CamlBuilder\project.json --configuration $configuration --out $output_folder }
	exec { dnu build $source_folder\CamlBuilder.UnitTests\project.json --configuration $configuration --out $output_folder }
}

task test { 
    'Run tests!'
}

task ci -depends compile {
}

task pack -depends test {
	$global:configuration = 'Release'
	exec { dnu pack $source_folder\CamlBuilder\project.json --configuration $configuration --out $output_folder }
}
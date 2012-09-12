#!/usr/bin/env ruby

require 'albacore'
require 'fileutils'

CONFIG        = 'Debug'
RAKE_DIR      = File.expand_path(File.dirname(__FILE__))
SOLUTION_DIR  = RAKE_DIR + "/src"
SRC_DIR       = SOLUTION_DIR + "/src/"
SOLUTION_FILE = 'JaySmith.DomainEvents.sln'
NUGET         = SOLUTION_DIR + "/.nuget/nuget.exe"

# --------------------------------------------------------------------------------------------
task :default                     => ['build:msbuild']
task :package                     => ['package:packall']
task :push                        => ['package:pushall']

namespace :build do

  msbuild :msbuild, [:targets] do |msb, args|
    args.with_defaults(:targets => :Build)
    msb.properties :configuration => CONFIG
    msb.targets args[:targets]
    msb.solution = "#{SOLUTION_DIR}/#{SOLUTION_FILE}"
  end
  
end

namespace :package do
	
	def create_packs()
		sh 'src/.nuget/nuget.exe pack src/JaySmith.DomainEvents/JaySmith.DomainEvents.csproj -o pack'
		sh 'src/.nuget/nuget.exe pack src/JaySmith.DomainEvents.StructureMap/JaySmith.DomainEvents.StructureMap.csproj -o pack'
	end
		
	task :packall => [ :clean ] do
		Dir.mkdir('pack')
		create_packs	
		Dir.glob('pack/*') { |file| FileUtils.move(file,'nuget/') }
		Dir.rmdir('pack')
	end
	
	task :pushall => [ :clean ] do
		Dir.mkdir('pack')
		create_packs	
		Dir.chdir('pack')
		Dir.glob('*').each do |file| 
			sh '../src/.nuget/nuget.exe push ' + file
			FileUtils.move(file,'../nuget/')
		end
		Dir.chdir('..')
		Dir.rmdir('pack')
	end
	
	task :clean do
		if Dir.exists? 'pack' 
			Dir.chdir('pack')
			Dir.glob('*').each do |file| 
				rm file
			end
			Dir.chdir('..')
			Dir.rmdir('pack')
		end
	end
end
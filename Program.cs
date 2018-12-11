using System;
using System.IO;
using System.Collection.Generic;

namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        { Console.WriteLine("Custom File Parser. v1.0. I owe Jeff for writing this....and Christmas is just around the corner....just saying.");
            Console.WriteLine("Hey Tom, what file am I parsing?");
            
            var fileName = Console.ReadLine();
            if(!File.Exists(fileName)){
                Console.WriteLine("Try again dipshit, that file doesn't exist");
                return;
            }
            var outputRecord = new List<GroupRecord>();
            using (var reader = new StreamReader("JeffSample.csv")){
                var currentgroup = string.Empty;
                while(!reader.EndOfStream){
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if(values.Count > 2 && values[0].IsNotNullOrEmpty()){
                        if (values[1].ToLowerInvariant == "group detail" || values[1].ToLowerInvariant) continue;
                        if (values[0].ToLowerInvariant == "group #") {
                            currentgroup = values[1];
                            continue;
                        }
                        try{
                            var groupRecord = new GroupRecord(values);
                            outputRecord.Add(groupRecord);
                        }
                        catch(Exception ex){
                            Console.WriteLine("Well that sucked. I could not parse this line. Go fix it.");
                            Console.WriteLine(values);
                            Console.WriteLine($"And here is what I know {ex.Message}");
                            Console.ReadLine();
                        }
                    }

                }

            }
        }
    }
}

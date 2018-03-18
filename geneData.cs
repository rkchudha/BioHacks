using System;
using static System.Console;
using System.Collections.Generic;
using System.IO; 

namespace rewrite
{
    static class Program
    {
        
        static void Main( )
        {
            
            // Create a FileStream to open the GWAS file and read it
            FileStream fileName = new FileStream (@"Chr20GWAStraits.tsv", FileMode.Open, FileAccess.Read);
            // Create a StreamReader linked to FileStream created above
            StreamReader reader = new StreamReader (fileName);
            // Read and discard the first line as it is only titles (no data)
            reader.ReadLine();
            
            // Create a new FileStream to create a new file
            FileStream newFile = new FileStream ("newFile",FileMode.Create, FileAccess.Write);
            // Create a StreamWriter linked to the FileStream created above
            StreamWriter writer = new StreamWriter(newFile);
            
            // Create a counter to keep track of how many lines there are (how many genes we come across)
            int counter1 = 0;
            // Create a string to hold a big string of the entire file
            string recordIn;
            // Create string arrays to hold the fields when printing as well as to break up the string later on
            List<string> gwa = new List<string>();
             List<string> gwadescrip = new List<string>();
            string [ ] fields;
            //loop through entire file line by line
            while(! reader.EndOfStream)
            {
                recordIn = reader.ReadLine();
                counter1++; // add 1 to the number of lines
                fields = recordIn.Split('\t'); // fields are split by tab delimiter 
                gwa.Add(fields[0]); // only the genes are added to the gwa array
                gwadescrip.Add(fields[1]); // while the descriptors are added to the gwa array
                writer.WriteLine(fields[0]); // write the gene on one line
                writer.WriteLine(fields[1]); // write the description on the other line
            }

            // Create a FileStream to open the function interaction file and read it
            FileStream fileName2 = new FileStream (@"Chr20FuncIntx.tsv", FileMode.Open, FileAccess.Read);
            // Create a StreamReader linked to FilStream created above
            StreamReader reader2 = new StreamReader(fileName2);
            // Create a new FileStream to create a new file
            FileStream newFile2 = new FileStream ("newFile2", FileMode.Create, FileAccess.Write);
            // Create. a StreamWriter linked to the FileStream created above
            StreamWriter writer2 = new StreamWriter(newFile);

            // create a counter to keep track of how many lines there are in the funcint file
            int counter2 = 0;
            // Create a string to hold a long string of the entire file
            List<string> recordIn2 = new List<string>();
            // loop through entire file line by line
            /*List<string> recordIn1 = new List<string>();
            while(! reader.EndOfStream)
            {
                recordIn1.Add(reader.ReadLine());
            }*/
            string recordIn1 = Convert.ToBase64String(File.ReadAllBytes(fileName));
            File.WriteAllBytes(fileName, Convert.FromBase64String( 

            while(! reader2.EndOfStream)
            {
                counter2++; //for each line, add to the counter
                recordIn2.Add(reader2.ReadLine()); // add the entire line, line by line
            }

            // create a new counter to count how many interactions genes have with eachother????? or diseases? look into this real quick
            int newcount = 0;
            string [ ] fields2;
            fields2 = recordIn1.Split('\t'); // fileds are split by tab delimiter
            // loop through lines of the gwas file
            for(int i= 0; i < counter1; i++) 
            {
                // loop through lines of the intfunc file
                for (int j=0; i < counter2; j++)
                {
                    // if we are looking at a gene in gwas file and a gene in the intfunc file
                    if(i%2 ==0 && j%3 == 1)
                    {
                        // if we are looking at the same genes!
                        if(fields2[i]==recordIn2[j])
                        {
                            writer2.Write(fields2[i] + "\t");
                             // if in the gwas file, the next gene is the same as the current gene
                            int v = 1;
                            while(fields2[i] == fields2[i+2*v])
                            {
                                writer2.Write(fields2[i+newcount] + "\t"); // writes the description in one column
                                v++;
                            }
                            // if in the intfunc file, the next gene is the same as the current gene
                            v = 1;
                            while((recordIn2[j]) == fields2[j+3*v])
                            {
                                writer2.Write(recordIn2[j+newcount] + ","); // writes genes that the current gene interacts with in a list form separated by commmas
                                newcount++; 
                                v++;
                                // move to the next gene in the intfunc file
                            }
                            // write the number of times a gene is similar to another gene
                            writer2.Write("\t" + newcount);
                        }
                        // 
                        writer2.WriteLine("\t" + j++);
                        newcount = 0;
                    }
                }
            }
            
            reader.Dispose();
            fileName.Dispose();
            writer.Dispose();
            newFile.Dispose();
            reader2.Dispose();
            fileName2.Dispose();
            writer2.Dispose();
            newFile2.Dispose();

        
        }
    }
}

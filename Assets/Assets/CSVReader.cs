using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

  /* This reader takes a flat CSV file with header columns and creates a Dictionary for each row of data. 
    All of these records are in turn stored in a Dictionary*/
public class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))"; // Define delimiters, regular expression craziness
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r"; // Define line delimiters, regular experession craziness
    static char[] TRIM_CHARS = { '\"' };
    public static Dictionary<string, Dictionary<string, string>> ReadFile(string file, string key_) //Declare method
    {
        Debug.Log("CSVReader is trying to read " + file); // Print filename, make sure parsed correctly

        //Put all data in a dictionary keyed by a string (e.g. GUID, OBJECTID or some other index accessible from the shape files)
        //The object cotaining each record from each row is itself a dictionary
        var records = new Dictionary<string, Dictionary<string, string>>(); 
        
        //Load the file named in the argument of the function as a TextAsset
        TextAsset data = Resources.Load(file) as TextAsset;
        
        if(data==null){
            return null;
        }

        // Debug.Log("TextAsset Data loaded:\n" + data); // Print raw data, make sure parsed correctly
        
        // Extract the text from the TextAsset
        var rows = Regex.Split(data.text, LINE_SPLIT_RE); // Split data.text into rows using LINE_SPLIT_RE characters
        /*** TODO: Set a default object if data is empty or corrupted ***/
        if (rows.Length <= 1) return records; //Check that there is more than one line
        string [] headers = Regex.Split(rows[0], SPLIT_RE); //Split header (element 0 from top row of CSV)
        // Debug.Log("headers:\n" + string.Join(", ",headers));
      
        // Loop through rows array, add each to outer Dictionary as a record (ignore top row with headers)keyed with the chosen header as index
        // Within each record add the available values for each variable keyed with the corresponding header
        for (var i = 1; i < rows.Length; i++)

        {
            Dictionary<string, string> record = new Dictionary <string, string>();   
            // Debug.Log("line #"+i+": " + rows[i]);
            var values = Regex.Split(rows[i], SPLIT_RE); //Split line according to SPLIT_RE, store in var (usually string array)
            if (values.Length == 0 || values[0] == "") {
                Debug.Log("ERROR: No rows of data were found in the input file "+file);
                continue; // Skip to end of loop if value is 0 length OR first value is empty
            }
            
            if (values.Length != headers.Length) {
                Debug.Log("ERROR:  Header count and number of row values count mismatch in file "+file);
                continue; // Skip if the number of values != no of headers
            }

            // Loop through every header and add the record to the inner Dictionary for each record
            for (var j = 0; j < headers.Length; j++)
            {
                string key = headers[j];
                key = key.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", ""); // This is where the headers are parsed
                
                string value = values[j]; 
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", ""); // This is where the values are parsed
                record.Add(key, value);
                // if(i==1){
                // Debug.Log("record: "+key+": "+record[key]);
                // };
            }
            
            //Use the value of OBJECTID as the key for the dictionary
            /***@ TODO: This assumes OBJECTID is the first column- make  more flexible***/
            // Debug.Log("Adding "+values[0]+", "+record.ToString());
            records.Add(values[0], record);
     
        }
        return records; 
    }
}
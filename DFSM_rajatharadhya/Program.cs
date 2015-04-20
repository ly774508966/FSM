/**
 * Author- Rajath Aradhya Mysore Shekar
 * Course - CS5800
 * Assignment 1
 * Date - 2/9/2015
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DFSM_rajatharadhya
{
    /*! \brief Driving Program */
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader DFSMReader = new StreamReader("DFSM.txt");
            /*! \brief Reading DFSM from a text file.
             *          
             *   text files location is in the project folder under bin\debug\DFSM.txt or input.txt
             *   streamreader is used to read from a text file. 
             *   first line defines DFSM 
             *   each variable is seperated using string.split with a delimeter.
             *   and everything is read into its respective Lists.
             *   After user enters the input, the input is checked for acceptance
             *   */
            string readingline =  DFSMReader.ReadLine();
            string[] line = readingline.Split('}');
            List<string> K = new List<string>();    /*!< finite set of states */
            List<char> sigma = new List<char>();    /*!< input alphabets  */
            List<Delta> delta = new List<Delta>();  /*!< trasition function */
            string s;                               /*!< start state */
            List<string> A = new List<string>();    /*!< accepting states */  
            line[0] = line[0].Substring(2);
            K = line[0].Split(',').ToList<string>();

            line[1] = line[1].Substring(2);
            
            int j = 0;
            foreach (string str in line[1].Split(','))
            {
                sigma.Add (Convert.ToChar(str));
                j++;
            }
            
            string[] restOfTheLine = line[2].Split(',');
            s = restOfTheLine[2];

            A.Add(restOfTheLine[3].Substring(1));
            for(int i = 4; i < restOfTheLine.Length ; i++)
            {
                A.Add(restOfTheLine[i]);
            }
            while ((readingline = DFSMReader.ReadLine()) != null)
            {
                line = readingline.Split(',');
                delta.Add(new Delta(line[0].Substring(2), Convert.ToChar(line[1].Substring(0, 1)), line[2].Substring(0, 2)));
            }
            DFSMReader.Close();
            DFSM dfsm = new DFSM(K, sigma, delta, s, A);
            string inputs;
            StreamReader inputReader = new StreamReader("input.txt");
            while ((inputs = inputReader.ReadLine()) != null)
            {
                Console.WriteLine("Input --> " + inputs);
                dfsm.InputCheckAcceptance(inputs);
            }
            Console.ReadLine();
        }
    }
}

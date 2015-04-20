/**
 * Author- Rajath Aradhya Mysore Shekar
 * Course - CS5800
 * Assignment 1
 * Date - 2/9/2015
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSM_rajatharadhya
{

    /*! \brief Object Class 
     * 
     * Object for Delta
     * Every state is object.
     * Delta gives the picture of the DFSM
 */
   public class Delta 
    {
        public string StartState { get; private set; } /*!< Start state. */
        public char InputSymbol { get; private set; } /*!< each input symbols */
        public string EndState { get; private set; } /*!< End states. */  
       public Delta(string startState, char inputSymbol, string endState)
       {
           StartState = startState;  /*!< Start state. */
           InputSymbol = inputSymbol; /*!< each input symbols */
           EndState = endState;  /*!< End states. */  
      }
       /*! \brief Formatting  */
       public override string ToString() /*!< Formatting  */  
       {
           return string.Format("({0}, {1}) , {2}", StartState, InputSymbol, EndState);
       }
    }
}

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
    /*! \brief Constructor */
    public class DFSM
    {
        private readonly List<string> K = new List<string>();    /*!< finite set of states */
        private readonly List<char> Sigma = new List<char>();    /*!< input alphabets  */
        private readonly List<Delta> deltA = new List<Delta>();  /*!< trasition function */
        private string S;                                        /*!< start state */
        private readonly List<string> A = new List<string>();    /*!< accepting states */
        /*! \brief Constructor */
      public DFSM(List<string> k, List<char> sigma, List<Delta> delta, string s, List<string> a)
      {
          K = k.ToList();          
          Sigma = sigma.ToList();  
         AddDelta(delta);
         AddInitialState(s);
         Acceptingstates(a);
      }

      private bool PreviousStateDelta(Delta delt)  /*!< trasition function */
      {
          return deltA.Any(vari => vari.StartState == delt.StartState && vari.InputSymbol == delt.InputSymbol);
          /*!< return true if start state is same for the symbol */
      }
      private bool ValidDelta(Delta delt)
      {
          return K.Contains(delt.StartState) && K.Contains(delt.EndState) &&
                 Sigma.Contains(delt.InputSymbol) && /*!< check if start and end state is in delta and also check if thsymbol is valid */
                 !PreviousStateDelta(delt);   
      }

      private void AddDelta(List<Delta> delta) /*!< Setting all transition states */  
      {
          foreach (Delta del in delta.Where(ValidDelta))
          {
              deltA.Add(del);
          }
      }

      private void AddInitialState(string s)
      {
          if (s != null && K.Contains(s))
          {
              S = s;/*!< setting intial state */ 
          }
      }

      private void Acceptingstates(List<string> acceptingstates)
      {
          foreach (string acceptState in acceptingstates.Where(finalState => K.Contains(finalState)))
          {
              A.Add(acceptState); /*!< setting accepting state */ 
          }
      }

      /*! InputCheckAcceptance is used to check if the input entered by user is acceppted or rejected
       * 
       * I have considered the textbook example on page 58(which can be changed)
       * input abbabab will be accepted according to example and is verified in the program. 
       * We can enter any inputs to check if it is accepted or rejected.
       * for every input transition of state is taken place.
       * in the end after the last input is read and last transition takes place, then we can know if the
       * input is accepted. 
       * If last transition state is a accepting state then the given inputs is accepted.
      */
      public void InputCheckAcceptance(string input) /*!< input from the file */ 
      {
          if (InputValidate(input) && ValidateDFSM())
          {
              return;
          }
          string currentState = S;
          StringBuilder trace = new StringBuilder();
          foreach (char inputSym in input.ToCharArray())
          {
              Delta del = deltA.Find(t => t.StartState == currentState && t.InputSymbol == inputSym);
               
              if (del == null)
              {
                  return;
              }
              currentState = del.EndState;
              trace.Append(del + "\n");
          }
          if (A.Contains(currentState))
          {
              Console.WriteLine("Input Accepted\n Trace -->\n" + trace);
              return; 
          }
          Console.WriteLine("Rejected \nStopped state " + currentState);
          Console.WriteLine(trace.ToString());
          /*!< returns if it is acccepted or rejected */ 
      }

      
      /*!
        To check if the input entered by user is valid
      */
      private bool InputValidate(string inputs) /*!< input from the file  */ 
      {
          foreach (char input in inputs.ToCharArray().Where(input => !Sigma.Contains(input)))
          {
              Console.WriteLine(input + " --> wrong input \n");
              return true;
          }
          return false; /*!< true if input is valid */ 
      }

      /*!
      To check if DFSM has valid initial state and accepting state
    */
      private bool ValidateDFSM()
      {
          if (CheckIntialState())
          {
              Console.WriteLine("Missing intial state");
              return true;
          }
          if (checkAcceptingState())
          {
              Console.WriteLine("Missing final state");
              return true;
          }
          return false; /*!< return true if DFSM is valid */ 
      }



      private bool CheckIntialState()
      {
          return string.IsNullOrEmpty(S);
      }

      private bool checkAcceptingState()
      {
          return A.Count == 0;
      }

    }
}

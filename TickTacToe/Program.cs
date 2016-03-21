using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTacToe
{
    class Program
    {

        static void Main(string[] args)
        {
            string firstPlayer;
            string secondPlayer;
            int[] positionA = { 0, 0, 0, 0, 0 };
            int[] positionB = { 0, 0, 0, 0, 0 };
            int userAIndex = 0;
            int userBIndex = 0;

            Console.SetWindowSize(70, 52);//Set window size so that users can see the blank play table
            
            Console.Title = "Tick Tac Toe";
            Console.WriteLine("Please enter the first player's name (will have play symbol \"O\"): ");
            firstPlayer = Console.ReadLine();
            Console.WriteLine("Please enter the second player's name (will have play symbol \"X\"): ");
            secondPlayer = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(" 1 | 2 | 3");
            Console.WriteLine(" ---------");
            Console.WriteLine(" 4 | 5 | 6");
            Console.WriteLine(" ---------");
            Console.WriteLine(" 7 | 8 | 9");
            Console.WriteLine();
            
            //Set blank play table and set cursor back to original position
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.SetCursorPosition(0, 45);
            Console.WriteLine("   |   |   ");
            Console.WriteLine("-----------");
            Console.WriteLine("   |   |   ");
            Console.WriteLine("-----------");
            Console.WriteLine("   |   |   ");
            Console.WriteLine();
            Console.SetCursorPosition(left, top);
            
            for (int i = 1; i < 10; i++)
            {
                int j = i % 2;
                if(j==1)
                {
                    Console.WriteLine("{0}, please enter a number representing your ticking position: ", firstPlayer);
                    string pA = Console.ReadLine();
                    //ensure(s) that player1 enters an interger
                    try {

                        int p1 = Convert.ToInt32(pA);
                           
                        //ensure(s) that Player 1 enteres validatble integer (from 1 to 9)
                        if (p1 > 9 | p1 < 1)
                        {
                            Console.WriteLine("Please enter a number betwenn 1 and 9");
                            i--;
                            continue;
                        }
                        //if is valid, now check if the number has already been played
                        else
                        {
                            bool continueTopLoop = false;

                            for (int index = 0; index < 5; index++)
                            {
                                if(ConvertNumber(p1)==positionA[index]|ConvertNumber(p1)==positionB[index])
                                {
                                    Console.WriteLine("Please enter a number different from numbers that had been entered");
                                    continueTopLoop = true;
                                    i--;
                                }
                            }

                            if (continueTopLoop == true)
                            {
                                continue;
                            }

                            int left1 = Console.CursorLeft;
                            int top1 = Console.CursorTop;
                            int left2 = GetLeft(p1);
                            int top2 = GetTop(p1);
                            Console.SetCursorPosition(left2, top2);
                            Console.Write("O");
                            Console.SetCursorPosition(left1, top1);
                            positionA[userAIndex] = ConvertNumber(p1);
                            userAIndex++;
                        }

                    checkIfWin(firstPlayer, positionA);

                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Please check your input is integer");
                        i--;
                        continue;
                    }

                    

                }


                else
                {
                    Console.WriteLine("{0}, please enter a number representing your ticking position: ", secondPlayer);
                    string pB = Console.ReadLine();
                    try
                    {

                        int p2 = Convert.ToInt32(pB);


                        //ensure(s) that Player 1 enteres validatble integer 
                        if (p2 > 9 | p2 < 1)
                        {
                            Console.WriteLine("Please enter a number betwenn 1 and 9");
                            i--;
                            continue;
                        }
                        //it is valid, now check if the number has already been played
                        else
                        {
                            bool continueTopLoop = false;

                            for (int index = 0; index < 5; index++)
                            {
                                if (ConvertNumber(p2) == positionB[index]|ConvertNumber(p2)== positionA[index])
                                {
                                    Console.WriteLine("Please enter a number different from numbers that had been entered");
                                    continueTopLoop = true;
                                    i--;
                                }
                            }

                            if (continueTopLoop == true)
                            {
                                continue;
                            }

                            int left1 = Console.CursorLeft;
                            int top1 = Console.CursorTop;
                            int left2 = GetLeft(p2);
                            int top2 = GetTop(p2);
                            Console.SetCursorPosition(left2, top2);
                            Console.Write("X");
                            Console.SetCursorPosition(left1, top1);
                            positionB[userAIndex] = ConvertNumber(p2);
                            userBIndex++;
                        }

                        checkIfWin(secondPlayer, positionB);

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please check your input is integer");
                        i--;
                        continue;
                    }
                }

            }
            Console.WriteLine("No one wins, please any key to exist");
            Console.ReadKey();
            Environment.Exit(0);

        }

        //Check if the player wins or not by adding up every three of his/her inputs' represented vales
        //If the sum equals to certian number, the player wins.
        static void checkIfWin(string playerName, int[] position)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (i != j && i != k && j != k)
                        {
                            sum = 0;
                            sum = position[i] + position[j] + position[k];
                            if (sum == 111 | sum == 111000 | sum == 111000000 | sum == 100010001 | sum == 1010100 | sum == 1001001 |sum==10010010|sum==100100100)
                            {
                                Console.WriteLine("{0} wins!!", playerName);
                                Console.WriteLine("Please press any key to exist");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }
                        }
                    }
                }
            }
        }

        // Determine where "X" or "O" symble shoud be put
        static int GetLeft(int position)
        {
            switch(position)
            {
                case 1:
                    return 0;
                case 2:
                    return 4;
                case 3:
                    return 8;
                case 4:
                    return 0;
                case 5:
                    return 4;
                case 6:
                    return 8;
                case 7:
                    return 0;
                case 8:
                    return 4;
                case 9:
                    return 8;
                default:
                    return 0;
            }
        }

        // Determine where "X" or "O" symble shoud be put
        static int GetTop(int position)
        {
            if(position==1|position==2|position==3)
            {
                return 45;
            }
            else if(position==4|position==5|position==6)
            {
                return 47;
            }
            else
            {
                return 49;
            }
        }

        //Convert position to integer(value) that represent the position
        static int ConvertNumber(int position)
        {
            switch (position)
            {
                case 1:
                    return 1;
                case 2:
                    return 10;
                case 3:
                    return 100;
                case 4:
                    return 1000;
                case 5:
                    return 10000;
                case 6:
                    return 100000;
                case 7:
                    return 1000000;
                case 8:
                    return 10000000;
                case 9:
                    return 100000000;
                default:
                    return 0;
            }
        }
    }
}

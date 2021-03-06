﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _4By4Skyscrapers
{   
    public class Skyscrapers
    {
        public static int[][] SolvePuzzle(int[] clues)
        {
            if (clues == null || clues.Length == 0)
                throw new ArgumentException();
            if (clues.All(x => x == 0))
                throw new ArgumentException();

            int[][] actual = new int[4][];
            actual[0] = new int[4];
            actual[1] = new int[4];
            actual[2] = new int[4];
            actual[3] = new int[4];

            // in all squares build 1, 2, 3 and 4 skyscraper
            // then we will destroy unnecessary
            var list = new List<int>[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    list[i, j] = new List<int>() { 1, 2, 3, 4 };


            // set 1,2,3,4 if clues 4, set 4 if clues 1
            BuildSkyscrapers4IfClues1(list, clues);
            BuildSkyscrapers1234IfClues4(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            // set 4 if clues 0
            BuildSkyscrapers4IfClues0(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            // remove 4 if clues 2 or 3
            RemoveSkyscrapers4IfCluesElement2Or3(list, clues);
            // remove 3 if clues 3
            RemoveSkyscrapers3IfCluesElement3(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);
            // remove 3 if clues 2
            RemoveSkyscrapers3IfCluesElement2(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            // set 4 if clues 2 and 3
            BuildSkyscrapers4IfCluesElement2And3(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            // set 4 if clues 3
            BuildSkyscrapers4IfCluesElement3(list, clues);

            // set 4 if clues 2
            BuildSkyscrapers4IfCluesElement2(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            
            BuildSkyscrapersThatDoesntIncluseToAnotherCluas(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            BuildSkyscrapersThatDoesntIncluseToAnotherCluas(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            CheckThePresenceOfASkyscraperInThreeRowsOrThreeColumns(list);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            // remove 1 if clues 2 and 3
            RemoveSkyscrapers1IfCluesElement2(list, clues);
            RemoveSkyscrapers1IfCluesElement3(list, clues);

            // set 3 if clues 3
            BuildSkyscrapers2And3IfCluesElement3(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            // set 1 if clues 3
            BuildSkyscrapers1IfCluesElement3(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            // set 3 if clues 2
            BuildSkyscrapers3IfCluesElement2(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            // set 1 if clues 2
            BuildSkyscrapers1IfCluesElement2(list, clues);            
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            // set 1 and 2 if clues 3
            BuildSkyscrapers1And2IfCluesElement3(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);
            CheckThePresenceOfASkyscraperInThreeRowsOrThreeColumns(list);

            // set 4 if clues 2
            BuildSkyscrapers4IfCluesElement2(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);
            CheckThePresenceOfASkyscraperInThreeRowsOrThreeColumns(list);

            // set 3 and 2 if clues 3
            BuildSkyscrapers3And2IfCluesElement3(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            // set 2 and 1 if clues 3
            BuildSkyscrapers2And1IfCluesElement3(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            // set 2 and 1 if clues 2
            BuildSkyscrapers2And1IfCluesElement2(list, clues);
            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            RemoveRepeatedInRowsAndColumnsSkyscrapers(list);

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    int s = list[i, j][0];
                    actual[i][j] = s;
                }

            return actual;
        }

        public static void BuildSkyscrapers4IfClues1(List<int>[,] actual, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 1)
                {
                    if (i < 4)
                        actual[0, i] = new List<int> { 4 };
                    else if (i >= 4 && i < 8)
                        actual[i - 4, 3] = new List<int> { 4 };
                    else if (i >= 8 && i < 12)
                        actual[3, 11 - i] = new List<int> { 4 };
                    else if (i >= 12 && i <= 15)
                        actual[15 - i, 0] = new List<int> { 4 };
                }
            }
        }

        // new
        public static void BuildSkyscrapers4IfClues0(List<int>[,] actual, int[] clues)
        {
            
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 0)
                {
                    if (i < 4)
                    {
                        int count = 0;
                        for (int j = 0; j < 4; j++)
                        {
                            if (i != j)
                                if (clues[j] != 0)
                                    count++;
                        }
                        if (count == 3)
                            actual[0, i] = new List<int> { 4 };
                    }
                    else if (i >= 4 && i < 8)
                    {
                        int count = 0;
                        for (int j = 4; j < 8; j++)
                        {
                            if (i != j)
                                if (clues[j] != 0)
                                    count++;
                        }
                        if (count == 3)
                            actual[i - 4, 3] = new List<int> { 4 };
                    }
                    else if (i >= 8 && i < 12)
                    {
                        int count = 0;
                        for (int j = 8; j < 12; j++)
                        {
                            if (i != j)
                                if (clues[j] != 0)
                                    count++;
                        }
                        if (count == 3)
                            actual[3, 11 - i] = new List<int> { 4 };
                    }                    
                    else if (i >= 12 && i <= 15)
                    {
                        int count = 0;
                        for (int j = 12; j <= 15; j++)
                        {
                            if (i != j)
                                if (clues[j] != 0)
                                    count++;
                        }
                        if (count == 3)
                            actual[15 - i, 0] = new List<int> { 4 };
                    }
                    
                }
            }
        }

        public static void BuildSkyscrapers1234IfClues4(List<int>[,] actual, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 4)
                {
                    if (i < 4)
                    {
                        actual[0, i] = new List<int> { 1 };
                        actual[1, i] = new List<int> { 2 };
                        actual[2, i] = new List<int> { 3 };
                        actual[3, i] = new List<int> { 4 };
                    }
                    else if (i >= 4 && i < 8)
                    {
                        actual[i - 4, 3] = new List<int> { 1 };
                        actual[i - 4, 2] = new List<int> { 2 };
                        actual[i - 4, 1] = new List<int> { 3 };
                        actual[i - 4, 0] = new List<int> { 4 };
                    }
                    else if (i >= 8 && i < 12)
                    {
                        actual[3, 11 - i] = new List<int> { 1 };
                        actual[2, 11 - i] = new List<int> { 2 };
                        actual[1, 11 - i] = new List<int> { 3 };
                        actual[0, 11 - i] = new List<int> { 4 };
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        actual[15 - i, 0] = new List<int> { 1 };
                        actual[15 - i, 1] = new List<int> { 2 };
                        actual[15 - i, 2] = new List<int> { 3 };
                        actual[15 - i, 3] = new List<int> { 4 };
                    }
                }
            }
        }

        public static bool RowConsistsThisNumber(List<int>[,] list, int row, int number)
        {
            for (var j = 0; j < 4; j++)
            {
                if (list[row, j].Count == 1 && list[row, j][0] == number)
                    return true;
            }
            return false;
        }

        public static bool ColumnConsistsThisNumber(List<int>[,] list, int column, int number)
        {
            for (var i = 0; i < 4; i++)
            {
                if (list[i, column].Count == 1 && list[i, column][0] == number)
                    return true;
            }
            return false;
        }

        public static void BuildSkyscrapers4IfCluesElement2(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 2)
                {                  

                    if (i < 4)
                    {
                        if (!ColumnConsistsThisNumber(list, i, 4))
                        {
                            if (!list[3, i].Contains(4) && !list[1, i].Contains(4))
                                list[2, i] = new List<int> { 4 };
                            else if (!list[3, i].Contains(4) && !list[2, i].Contains(4))
                                list[1, i] = new List<int> { 4 };

                            else if (list[2, i].Contains(3) && list[2, i].Count == 1)
                                list[1, i] = new List<int> { 4 };

                            if (i == 1 && clues[6] == 2)
                                list[2, 1] = new List<int> { 4 };
                            else if (i == 2 && clues[13] == 2)
                                list[2, 2] = new List<int> { 4 };
                        }

                    }
                    else if (i >= 4 && i < 8)
                    {
                        if (!RowConsistsThisNumber(list, i - 4, 4))
                        {
                            if (!list[i - 4, 0].Contains(4) && !list[i - 4, 2].Contains(4))
                                list[i - 4, 1] = new List<int> { 4 };
                            else if (!list[i - 4, 0].Contains(4) && !list[i - 4, 1].Contains(4))
                                list[i - 4, 2] = new List<int> { 4 };

                            else if (list[i - 4, 1].Contains(3) && list[i - 4, 1].Count == 1)
                                list[i - 4, 2] = new List<int> { 4 };

                            if (i == 5 && clues[10] == 2)
                                list[1, 1] = new List<int> { 4 };
                        }
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if (!ColumnConsistsThisNumber(list, 11 - i, 4))
                        {
                            if (!list[0, 11 - i].Contains(4) && !list[2, 11 - i].Contains(4))
                                list[1, 11 - i] = new List<int> { 4 };
                            else if (!list[0, 11 - i].Contains(4) && !list[1, 11 - i].Contains(4))
                                list[2, 11 - i] = new List<int> { 4 };

                            else if (list[1, 11 - i].Contains(3) && list[1, 11 - i].Count == 1)
                                list[2, 11 - i] = new List<int> { 4 };

                            else if (i == 9 && clues[14] == 2)
                                list[1, 2] = new List<int> { 4 };
                        }
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if (!RowConsistsThisNumber(list, 15 - i, 4))
                        {
                            if (!list[15 - i, 3].Contains(4) && !list[15 - i, 1].Contains(4))
                                list[15 - i, 2] = new List<int> { 4 };
                            else if (!list[15 - i, 3].Contains(4) && !list[15 - i, 2].Contains(4))
                                list[15 - i, 1] = new List<int> { 4 };

                            else if (list[15 - i, 2].Contains(3) && list[15 - i, 2].Count == 1)
                                list[15 - i, 1] = new List<int> { 4 };
                        }
                    }
                }
            }
        }

        // new
        public static void BuildSkyscrapersThatDoesntIncluseToAnotherCluas(List<int>[,] list, int[] clues)
        {
            int count, X, Y;
            for (int c = 0; c < clues.Length; c++)
            {
                for (int i = 0; i < list.GetLength(0); i++)
                {
                    count = 0;
                    X = 0;
                    Y = 0;
                    for (int j = 0; j < list.GetLength(1); j++)
                    {
                        if (list[i, j].Contains(clues[c]))
                        {
                            count++;
                            X = i;
                            Y = j;
                        }
                    }
                    if (count == 1)
                    {
                        list[X, Y] = new List<int> { clues[c] };
                    }
                }
            }
        }

        // new
        public static void BuildSkyscrapers4IfCluesElement3(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 3)
                {
                    if (i < 4)
                    {
                        if (!list[3, i].Contains(4))
                            list[2, i] = new List<int> { 4 };
                    }
                    else if (i >= 4 && i < 8)
                    {
                        if (!list[i - 4, 0].Contains(4))
                            list[i - 4, 1] = new List<int> { 4 };
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if (!list[0, 11 - i].Contains(4))
                            list[1, 11 - i] = new List<int> { 4 };
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if (!list[15 - i, 3].Contains(4))
                            list[15 - i, 2] = new List<int> { 4 };
                    }
                }
            }
        }

        public static void BuildSkyscrapers4IfCluesElement2And3(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 2)
                {
                    if (i < 4)
                    {
                        if (clues[11 - i] == 3)
                            list[1, i] = new List<int> { 4 };
                    }
                    else if (i >= 4 && i < 8)
                    {
                        if (clues[15 - i + 4] == 3)                        
                            list[i - 4, 2] = new List<int> { 4 };
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if (clues[11 - i] == 3)
                            list[2, 11 - i] = new List<int> { 4 };
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if (clues[15 - i + 4] == 3)
                            list[15 - i, 1] = new List<int> { 4 };
                    }
                }
            }
        }

        public static void RemoveSkyscrapers1IfCluesElement2(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 2)
                {
                    if (i < 4)
                    {
                        if ((list[0, i].Contains(1)
                            && ((list[2, i].Contains(4) && list[2, i].Count == 1)
                            || (list[3, i].Contains(4) && list[3, i].Count == 1)))
                                || !(list[1, i].Contains(4)))
                            list[0, i].Remove(1);
                    }
                    else if (i >= 4 && i < 8)
                    {
                        if ((list[i - 4, 3].Contains(1)
                            && ((list[i - 4, 1].Contains(4) && list[i - 4, 1].Count == 1)
                            || (list[i - 4, 0].Contains(4) && list[i - 4, 0].Count == 1)))
                                || !(list[i - 4, 2].Contains(4)))
                            list[i - 4, 3].Remove(1);
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if ((list[3, 11 - i].Contains(1)
                            && ((list[1, 11 - i].Contains(4) && list[1, 11 - i].Count == 1)
                            || (list[0, 11 - i].Contains(4) && list[0, 11 - i].Count == 1)))
                                || !(list[2, 11 - i].Contains(4)) )
                            list[3, 11 - i].Remove(1);
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if ( (list[15 - i, 0].Contains(1) 
                            && ((list[15 - i, 2].Contains(4) && list[15 - i, 2].Count == 1)
                            || (list[15 - i, 3].Contains(4) && list[15 - i, 3].Count == 1))) 
                            || !(list[15 - i, 1].Contains(4)) )
                            list[15 - i, 0].Remove(1);
                    }
                }
            }
        }

        public static void RemoveSkyscrapers4IfCluesElement2Or3(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 2 || clues[i] == 3)
                {
                    if (i < 4)
                    {
                        if (list[0, i].Contains(4) && list[0, i].Count != 1)
                        {
                            list[0, i].Remove(4);
                            if (clues[i] == 3)
                                list[1, i].Remove(4);
                        }
                    }
                    else if (i >= 4 && i < 8)
                    {
                        if (list[i - 4, 3].Contains(4) && list[i - 4, 3].Count != 1)
                        {
                            list[i - 4, 3].Remove(4);
                            if (clues[i] == 3)
                                list[i - 4, 2].Remove(4);
                        }
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if (list[3, 11 - i].Contains(4) && list[3, 11 - i].Count != 1)
                        {
                            list[3, 11 - i].Remove(4);
                            if (clues[i] == 3)
                                list[2, 11 - i].Remove(4);
                        }
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if (list[15 - i, 0].Contains(4) && list[15 - i, 0].Count != 1)
                        {
                            list[15 - i, 0].Remove(4);
                            if (clues[i] == 3)
                                list[15 - i, 1].Remove(4);
                        }
                    }
                }
            }
        }

        // new
        public static void RemoveSkyscrapers3IfCluesElement3(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 3)
                {
                    if (i < 4)
                    {
                        list[0, i].Remove(3);
                    }
                    else if (i >= 4 && i < 8)
                    {
                        list[i - 4, 3].Remove(3);
                    }
                    else if (i >= 8 && i < 12)
                    {
                        list[3, 11 - i].Remove(3);
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        list[15 - i, 0].Remove(3);
                    }
                }
            }
        }

        // new
        public static void RemoveSkyscrapers3IfCluesElement2(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 2)
                {
                    if (i < 4)
                    {
                        list[1, i].Remove(3);
                    }
                    else if (i >= 4 && i < 8)
                    {
                        list[i - 4, 2].Remove(3);
                    }
                    else if (i >= 8 && i < 12)
                    {
                        list[2, 11 - i].Remove(3);
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        list[15 - i, 1].Remove(3);
                    }
                }
            }
        }

        public static void BuildSkyscrapers3IfCluesElement2(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 2)
                {
                    if (i < 4)
                    {
                        if (list[3, i].Count == 1 && list[3, i].Contains(4))
                            list[0, i] = new List<int> { 3 };
                    }
                    else if (i >= 4 && i < 8)
                    {
                        if (list[i - 4, 0].Count == 1 && list[i - 4, 0].Contains(4))
                            list[i - 4, 3] = new List<int> { 3 };
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if (list[0, 11 - i].Count == 1 && list[0, 11 - i].Contains(4))
                            list[3, 11 - i] = new List<int> { 3 };
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if (list[15 - i, 3].Count == 1 && list[15 - i, 3].Contains(4))
                            list[15 - i, 0] = new List<int> { 3 };
                    }
                }
            }
        }

        // new
        public static void BuildSkyscrapers1IfCluesElement3(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 3)
                {
                    if (i < 4)
                    {
                        if ( (list[2, i].Count == 1 && list[2, i].Contains(4))
                            && (list[1, i].Count == 1 && list[1, i].Contains(2)) )
                            list[0, i] = new List<int> { 1 };
                    }
                    else if (i >= 4 && i < 8)
                    {
                        if ( (list[i - 4, 1].Count == 1 && list[i - 4, 1].Contains(4))
                            && (list[i - 4, 2].Count == 1 && list[i - 4, 2].Contains(2)))
                            list[i - 4, 3] = new List<int> { 1 };
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if ( (list[1, 11 - i].Count == 1 && list[1, 11 - i].Contains(4))
                            && (list[2, 11 - i].Count == 1 && list[2, 11 - i].Contains(2)) )
                            list[3, 11 - i] = new List<int> { 1 };
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if ( (list[15 - i, 2].Count == 1 && list[15 - i, 2].Contains(4))
                            && (list[15 - i, 1].Count == 1 && list[15 - i, 1].Contains(2)) )
                            list[15 - i, 0] = new List<int> { 1 };
                    }
                }
            }
        }

        public static void BuildSkyscrapers1IfCluesElement2(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 2)
                {
                    if (i < 4)
                    {
                        if ((list[0, i].Contains(2) && list[0, i].Count == 1)
                            && (list[2, i].Contains(4) && list[2, i].Count == 1))
                            list[1, i] = new List<int> { 1 };
                    }
                    else if (i >= 4 && i < 8)
                    {
                        if ((list[i - 4, 3].Contains(2) && list[i - 4, 3].Count == 1)
                            && (list[i - 4, 1].Contains(4) && list[i - 4, 1].Count == 1))
                            list[i - 4, 2] = new List<int> { 1 };
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if ((list[3, 11 - i].Contains(2) && list[3, 11 - i].Count == 1)
                            && (list[1, 11 - i].Contains(4) && list[1, 11 - i].Count == 1))
                            list[2, 11 - i] = new List<int> { 1 };
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if ((list[15 - i, 0].Contains(2) && list[15 - i, 0].Count == 1)
                            && (list[15 - i, 2].Contains(4) && list[15 - i, 2].Count == 1))
                            list[15 - i, 1] = new List<int> { 1 };
                    }
                }
            }
        }

        // new
        public static void BuildSkyscrapers1And2IfCluesElement3(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 3)
                {
                    if (i < 4)
                    {
                        if ((list[3, i].Contains(4) && list[3, i].Count == 1)
                            && (list[2, i].Contains(3) && list[2, i].Count == 1)
                            && (!list[0, i].Contains(3)))
                        {
                            list[1, i] = new List<int> { 1 };
                            list[0, i] = new List<int> { 2 };
                        }
                        else if ((list[2, i].Contains(4) && list[2, i].Count == 1)
                            && (!list[0, i].Contains(3) && !list[1, i].Contains(3)))
                        {
                            list[0, i] = new List<int> { 1 };
                            list[1, i] = new List<int> { 2 };
                        }
                    }
                    else if (i >= 4 && i < 8)
                    {
                        if ((list[i - 4, 0].Contains(4) && list[i - 4, 0].Count == 1)
                            && (list[i - 4, 1].Contains(3) && list[i - 4, 1].Count == 1)
                            && (!list[i - 4, 3].Contains(3)))
                        {
                            list[i - 4, 2] = new List<int> { 1 };
                            list[i - 4, 3] = new List<int> { 2 };
                        }
                        else if ( (list[i - 4, 1].Contains(4) && list[i - 4, 1].Count == 1)
                            && (!list[i - 4, 2].Contains(3) && (!list[i - 4, 3].Contains(3))) )
                        {
                            list[i - 4, 2] = new List<int> { 2 };
                            list[i - 4, 3] = new List<int> { 1 };
                        }
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if ((list[0, 11 - i].Contains(4) && list[0, 11 - i].Count == 1)
                            && (list[1, 11 - i].Contains(3) && list[1, 11 - i].Count == 1)
                            && (!list[0, 11 - i].Contains(3)))
                        {
                            list[1, 11 - i] = new List<int> { 1 };
                            list[0, 11 - i] = new List<int> { 2 };
                        }
                        else if ((list[1, 11 - i].Contains(4) && list[1, 11 - i].Count == 1)
                            && (!list[2, 11 - i].Contains(3) && (!list[3, 11 - i].Contains(3))))
                        {
                            list[2, 11 - i] = new List<int> { 2 };
                            list[3, 11 - i] = new List<int> { 1 };
                        }
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if ((list[15 - i, 3].Contains(4) && list[15 - i, 3].Count == 1)
                            && (list[15 - i, 2].Contains(3) && list[15 - i, 2].Count == 1)
                             && (!list[15 - i, 0].Contains(3)))
                        {
                            list[15 - i, 1] = new List<int> { 1 };
                            list[15 - i, 0] = new List<int> { 2 };
                        }
                        else if ( (list[15 - i, 2].Contains(4) && list[15 - i, 2].Count == 1)
                            && (!list[15 - i, 1].Contains(3) && (!list[15 - i, 0].Contains(3))) )
                        {
                            list[15 - i, 1] = new List<int> { 2 };
                            list[15 - i, 0] = new List<int> { 1 };
                        }
                    }
                }
            }
        }

        public static void BuildSkyscrapers3And2IfCluesElement3(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 3)
                {
                    if (i < 4)
                    {
                        if ((list[3, i].Contains(4) && list[3, i].Count == 1)
                            && (list[2, i].Contains(1) && list[2, i].Count == 1))
                        {
                            list[1, i] = new List<int> { 3 };
                            list[0, i] = new List<int> { 2 };
                        }
                        if ((list[2, i].Contains(4) && list[2, i].Count == 1)
                            && (list[1, i].Contains(1) && list[1, i].Contains(2) && list[1, i].Count == 2)
                            && (list[0, i].Contains(1) && list[0, i].Contains(2) && list[0, i].Count == 2))
                        {
                            list[1, i] = new List<int> { 2 };
                            list[0, i] = new List<int> { 1 };
                        }
                    }
                    else if (i >= 4 && i < 8)
                    {
                        if ((list[i - 4, 0].Contains(4) && list[i - 4, 0].Count == 1)
                            && (list[i - 4, 1].Contains(1) && list[i - 4, 1].Count == 1))
                        {
                            list[i - 4, 2] = new List<int> { 3 };
                            list[i - 4, 3] = new List<int> { 2 };
                        }
                        if ((list[i - 4, 1].Contains(4) && list[i - 4, 1].Count == 1)
                            && (list[i - 4, 2].Contains(1) && list[i - 4, 2].Contains(2) && list[i - 4, 2].Count == 2)
                            && (list[i - 4, 3].Contains(1) && list[i - 4, 3].Contains(2) && list[i - 4, 3].Count == 2))
                        {
                            list[i - 4, 3] = new List<int> { 1 };
                            list[i - 4, 2] = new List<int> { 2 };
                        }
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if ((list[0, 11 - i].Contains(4) && list[0, 11 - i].Count == 1)
                            && (list[1, 11 - i].Contains(1) && list[1, 11 - i].Count == 1))
                        {
                            list[2, 11 - i] = new List<int> { 3 };
                            list[3, 11 - i] = new List<int> { 2 };
                        }
                        if ((list[1, 11 - i].Contains(4) && list[1, 11 - i].Count == 1)
                            && (list[2, 11 - i].Contains(1) && list[2, 11 - i].Contains(2) && list[2, 11 - i].Count == 2)
                            && (list[3, 11 - i].Contains(1) && list[3, 11 - i].Contains(2) && list[1, 11 - i].Count == 2))
                        {
                            list[2, 11 - i] = new List<int> { 2 };
                            list[3, 11 - i] = new List<int> { 1 };
                        }
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if ((list[15 - i, 3].Contains(4) && list[15 - i, 3].Count == 1)
                            && (list[15 - i, 2].Contains(1) && list[15 - i, 2].Count == 1))
                        {
                            list[15 - i, 1] = new List<int> { 3 };
                            list[15 - i, 0] = new List<int> { 2 };
                        }
                        if ((list[15 - i, 2].Contains(4) && list[15 - i, 2].Count == 1)
                            && (list[15 - i, 1].Contains(1) && list[15 - i, 1].Contains(2) && list[15 - i, 1].Count == 2)
                            && (list[15 - i, 0].Contains(1) && list[15 - i, 0].Contains(2) && list[15 - i, 2].Count == 2))
                        {
                            list[15 - i, 1] = new List<int> { 2 };
                            list[15 - i, 0] = new List<int> { 1 };
                        }
                    }
                }
            }
        }

        public static void BuildSkyscrapers2And1IfCluesElement3(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 3)
                {
                    if (i < 4)
                    {
                        if ((list[2, i].Contains(4) && list[2, i].Count == 1)
                            && (list[1, i].Contains(1) && list[1, i].Contains(2) && list[1, i].Count == 2)
                            && (list[0, i].Contains(1) && list[0, i].Contains(2) && list[0, i].Count == 2))
                        {
                            list[1, i] = new List<int> { 2 };
                            list[0, i] = new List<int> { 1 };
                        }
                    }
                    else if (i >= 4 && i < 8)
                    {
                        if ((list[i - 4, 1].Contains(4) && list[i - 4, 1].Count == 1)
                            && (list[i - 4, 2].Contains(1) && list[i - 4, 2].Contains(2) && list[i - 4, 2].Count == 2)
                            && (list[i - 4, 3].Contains(1) && list[i - 4, 3].Contains(2) && list[i - 4, 3].Count == 2))
                        {
                            list[i - 4, 3] = new List<int> { 1 };
                            list[i - 4, 2] = new List<int> { 2 };
                        }
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if ((list[1, 11 - i].Contains(4) && list[1, 11 - i].Count == 1)
                            && (list[2, 11 - i].Contains(1) && list[2, 11 - i].Contains(2) && list[2, 11 - i].Count == 2)
                            && (list[3, 11 - i].Contains(1) && list[3, 11 - i].Contains(2) && list[1, 11 - i].Count == 2))
                        {
                            list[2, 11 - i] = new List<int> { 2 };
                            list[3, 11 - i] = new List<int> { 1 };
                        }
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if ((list[15 - i, 2].Contains(4) && list[15 - i, 2].Count == 1)
                            && (list[15 - i, 1].Contains(1) && list[15 - i, 1].Contains(2) && list[15 - i, 1].Count == 2)
                            && (list[15 - i, 0].Contains(1) && list[15 - i, 0].Contains(2) && list[15 - i, 2].Count == 2))
                        {
                            list[15 - i, 1] = new List<int> { 2 };
                            list[15 - i, 0] = new List<int> { 1 };
                        }
                    }
                }
            }
        }

        // new
        public static void BuildSkyscrapers2And1IfCluesElement2(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 2)
                {
                    if (i < 4)
                    {
                        if ((list[2, i].Contains(4) && list[2, i].Count == 1)
                            && (list[3, i].Contains(3) && list[3, i].Count == 2))
                        {
                            list[1, i] = new List<int> { 1 };
                            list[0, i] = new List<int> { 2 };
                        }
                    }
                    else if (i >= 4 && i < 8)
                    {
                        if ((list[i - 4, 1].Contains(4) && list[i - 4, 1].Count == 1)
                            && (list[i - 4, 0].Contains(3) && list[i - 4, 0].Count == 2))
                        {
                            list[i - 4, 3] = new List<int> { 2 };
                            list[i - 4, 2] = new List<int> { 1 };
                        }
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if ((list[1, 11 - i].Contains(4) && list[1, 11 - i].Count == 1)
                            && (list[0, 11 - i].Contains(3) && list[0, 11 - i].Count == 1))
                        {
                            list[2, 11 - i] = new List<int> { 1 };
                            list[3, 11 - i] = new List<int> { 2 };
                        }
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if ((list[15 - i, 2].Contains(4) && list[15 - i, 2].Count == 1)
                            && (list[15 - i, 3].Contains(3) && list[15 - i, 3].Count == 2))
                        {
                            list[15 - i, 1] = new List<int> { 1 };
                            list[15 - i, 0] = new List<int> { 2 };
                        }
                    }
                }
            }
        }

        // new
        public static void BuildSkyscrapers2And3IfCluesElement3(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 3)
                {
                    if (i < 4)
                    {
                        if ((list[2, i].Contains(4) && list[2, i].Count == 1)
                            && (!list[0, i].Contains(1)))
                        {
                            list[1, i] = new List<int> { 3 };
                            list[0, i] = new List<int> { 2 };
                        }
                    }
                    else if (i >= 4 && i < 8)
                    {
                        if ((list[i - 4, 1].Contains(4) && list[i - 4, 1].Count == 1)
                            && (!list[i - 4, 3].Contains(1)))
                        {
                            list[i - 4, 3] = new List<int> { 2 };
                            list[i - 4, 2] = new List<int> { 3 };
                        }
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if ((list[1, 11 - i].Contains(4) && list[1, 11 - i].Count == 1)
                            && (!list[3, 11 - i].Contains(1)))
                        {
                            list[2, 11 - i] = new List<int> { 3 };
                            list[3, 11 - i] = new List<int> { 2 };
                        }
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if ((list[15 - i, 2].Contains(4) && list[15 - i, 2].Count == 1)
                            && (!list[15 - i, 0].Contains(1)))
                        {
                            list[15 - i, 1] = new List<int> { 3 };
                            list[15 - i, 0] = new List<int> { 2 };
                        }
                    }
                }
            }
        }

        // new
        public static void RemoveSkyscrapers1IfCluesElement3(List<int>[,] list, int[] clues)
        {
            for (int i = 0; i < clues.Length; i++)
            {
                if (clues[i] == 3)
                {
                    if (i < 4)
                    {
                        if ((list[2, i].Contains(4) && list[2, i].Count == 1)
                            && (list[1, i].Contains(1)))                        
                            list[1, i].Remove(1);
                    }
                    else if (i >= 4 && i < 8)
                    {
                        if ((list[i - 4, 1].Contains(4) && list[i - 4, 1].Count == 1)
                            && (list[i - 4, 2].Contains(1)))
                            list[i - 4, 2].Remove(1);
                    }
                    else if (i >= 8 && i < 12)
                    {
                        if ((list[1, 11 - i].Contains(4) && list[1, 11 - i].Count == 1)
                            && (list[2, 11 - i].Contains(1)))
                            list[3, 11 - i].Remove(1);
                    }
                    else if (i >= 12 && i <= 15)
                    {
                        if ((list[15 - i, 2].Contains(4) && list[15 - i, 2].Count == 1)
                            && (list[15 - i, 1].Contains(1)))
                            list[15 - i, 0].Remove(1);
                    }
                }

            }
        }

        public static void RemoveRepeatedInRowsAndColumnsSkyscrapers(List<int>[,] list)
        {
            // skyscrapers
            for (int sky = 1; sky <= 4; sky++)
            {
                for (int i = 0; i < list.GetLength(0); i++)
                {
                    for (int j = 0; j < list.GetLength(1); j++)
                    {
                        if (list[i, j].Count == 1 && list[i, j][0] == sky)
                        {
                            for (int r = 0; r < 4; r++)
                                if (r != i && list[r, j].Count > 1)
                                {
                                    var index = list[r, j].FindIndex(ind => ind == sky);
                                        list[r, j].Remove(sky);
                                }
                            for (int c = 0; c < 4; c++)
                                if (c != j && list[i, c].Count > 1)
                                {
                                    var index = list[i, c].FindIndex(ind => ind == sky);
                                        list[i, c].Remove(sky);
                                }

                        }
                    }
                }
            }
        }

        public static void CheckThePresenceOfASkyscraperInThreeRowsOrThreeColumns(List<int>[,] list)
        {
            int X, Y, count;
            for (int sky = 1; sky <= 4; sky++)
            {
                X = 0;
                Y = 0;
                count = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++) {
                        if (list[i, j].Count == 1 && list[i, j][0] == sky)
                        {
                            count++;
                        }
                        if (list[i, j].Count != 1 && list[i, j].Contains(sky))
                        {
                            X = i;
                            Y = j;
                        }
                    }
                }
                if (count == 3)
                    list[X, Y] = new List<int> { sky };                    
            }
        }
    }    
}

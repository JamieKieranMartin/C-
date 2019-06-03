using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AssignmentCAB201
{
    class Tour
    {
        public float TOTAL_DISTANCE { get; set; }
        public TimeSpan START_TIME { get; set; }

        public Plane PLANE_SPECS { get; set; }
        public Station START_STATION { get; set; }
        public List<Station> INIT_STATIONS = new List<Station>();
        public List<Station> STATIONS = new List<Station>();
        public List<TimeSpan[]> TIMES = new List<TimeSpan[]>();
        public List<int> REFUEL_POS = new List<int>();

        /// <summary>
        /// Initilise new Tour
        /// </summary>
        /// <param name="stationList"></param>
        /// <param name="plane"></param>
        /// <param name="start"></param>
        public Tour(ref List<Station> stationList, ref Plane plane, ref string start)
        {
            try
            {
                PLANE_SPECS = plane;
                INIT_STATIONS = stationList;
                START_TIME = Convert.ToDateTime(start).TimeOfDay;
                START_STATION = INIT_STATIONS.ElementAt(0);
                //Add end post offices
                STATIONS.Add(START_STATION);
                STATIONS.Add(START_STATION);
            } catch (Exception e)
            {
                Console.Write($"TourInitialisationError: ");
                Console.WriteLine("Please ensure argument format of 'mail.txt[input stations file] plane.txt[plane spec file] 00:00[time] -o output.txt[optional output file]");
                throw;
            }
        }

        /// <summary>
        /// Test Inserts a Station, returns new total distance
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public float TestInsert(int pos, Station a)
        {
            try
            {
                // TAKE total distance remove trip where insert test happens, add the trips between the two points of insertion
                return (TOTAL_DISTANCE - CalcDist(STATIONS.ElementAt(pos - 1), STATIONS.ElementAt(pos))) + (CalcDist(STATIONS.ElementAt(pos - 1), a) + CalcDist(a, STATIONS.ElementAt(pos)));
            }
            catch (Exception e)
            {
                Console.Write($"TestInsertError: ");
                throw;
            }
        }

        /// <summary>
        /// Inserts a Station and adjusts total distance
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="a"></param>
        public void InsertStation(int pos, Station a)
        {
            try
            {
                // TAKE total distance remove trip where insert happens
                TOTAL_DISTANCE -= CalcDist(STATIONS.ElementAt(pos - 1), STATIONS.ElementAt(pos));
                // insert the trip to the position
                STATIONS.Insert(pos, a);
                // TAKE total distance add the trips between two points of insertion 
                TOTAL_DISTANCE += (CalcDist(STATIONS.ElementAt(pos - 1), STATIONS.ElementAt(pos)) + CalcDist(STATIONS.ElementAt(pos), STATIONS.ElementAt(pos + 1)));
            } catch (Exception e)
            {
                Console.Write($"InsertStationError: ");
                throw;
            }
        }

        /// <summary>
        /// Removes a Station from the list of Stations and adjusts total distance
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="a"></param>
        public void RemoveStation(int pos, Station a)
        {
            try
            {
                // remove left and right distance of element at position
                TOTAL_DISTANCE -= (CalcDist(STATIONS.ElementAt(pos - 1), a) + CalcDist(a, STATIONS.ElementAt(pos + 1)));
                // remove the station from list
                STATIONS.Remove(a);
                // add the distance between the two points either side of station
                TOTAL_DISTANCE += CalcDist(STATIONS.ElementAt(pos - 1), STATIONS.ElementAt(pos));
            }
            catch (Exception e)
            {
                Console.Write($"RemoveStationError: ");
                throw;
            }
        }

        /// <summary>
        /// Calculate Distance between two Stations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public float CalcDist(Station a, Station b)
        {
            try
            {
                return Convert.ToSingle(Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2)));
            }
            catch (Exception e)
            {
                Console.Write($"CalculateDistanceError: ");
                throw;
            }
        }

        /// <summary>
        /// Calculate Time between two Stations
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public float CalcTime(Station a, Station b)
        {
            try
            {
                return Convert.ToSingle(Math.Round(PLANE_SPECS.TAKE_OFF_TIME + ((CalcDist(a, b) / PLANE_SPECS.SPEED) * 60) + PLANE_SPECS.LANDING_TIME));
            }
            catch (Exception e)
            {
                Console.Write($"CalculateTimeError: ");
                throw;
            }
        }

        /// <summary>
        /// Level 1 optimisation
        /// </summary>
        public void Level1()
        {
            Console.WriteLine("Optimising tour length: Level 1...");
            try
            {
                // iterates over stations
                for (int i = 1; i < INIT_STATIONS.Count - 1; i++)
                {
                    // gets the station at each index
                    Station testStation = INIT_STATIONS.ElementAt(i);
                    float minDistance = float.MaxValue;
                    int bestPos = 0;
                    // finds the best position for it in the current list
                    for (int pos = 1; pos < STATIONS.Count; pos++)
                    {
                        // finds distance if the station were to be inserted
                        float distance = TestInsert(pos, testStation);
                        if (distance <= minDistance)
                        {
                            // set best position and new distance
                            bestPos = pos;
                            minDistance = distance;
                        }
                    }
                    // finally inserts the station once the best location is known
                    InsertStation(bestPos, testStation);
                }
            } catch (Exception e)
            {
                Console.Write($"Level1Error: ");
                throw;
            }
        }

        /// <summary>
        /// Level 2 optimisation. 
        /// </summary>
        public void Level2()
        {
            Console.WriteLine("Optimising tour length: Level 2...");
            try
            {
                bool loopCond = true;
                while (loopCond)
                {
                    loopCond = false;
                    // iterate over stations
                    for (int i = 1; i < INIT_STATIONS.Count - 1; i++)
                    {
                        Station testStation = INIT_STATIONS.ElementAt(i);
                        // set the best distance to the current distance
                        float currentBestDistance = TOTAL_DISTANCE;
                        // set the best position to the current position
                        int currentPos = STATIONS.IndexOf(testStation);

                        // remove the station from its original position
                        RemoveStation(currentPos, testStation);
                        // iterate over possible positions
                        for (int pos = 1; pos < (STATIONS.Count - 1); pos++)
                        {
                            // test insert the station into the position
                            float distance = TestInsert(pos, testStation);
                            if (distance < currentBestDistance)
                            {
                                // set the new position to the better position
                                currentPos = pos;
                                loopCond = true;
                                break;
                            } if (distance <= currentBestDistance)
                            {
                                loopCond = true;
                            }
                            loopCond = false;
                        }
                        //Insert the station into the best position
                        InsertStation(currentPos, testStation);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write($"Level2Error: ");
                throw;
            }
        }

        /// <summary>
        /// Level 3 initialiser
        /// </summary>
        public void Level3()
        {
            Console.WriteLine("Optimising tour length: Level 3...");
            TOTAL_DISTANCE = float.MaxValue;

            Level3Generate((INIT_STATIONS.Count - 1), INIT_STATIONS);
        }

        /// <summary>
        /// Swaps two stations give their indexes
        /// </summary>
        /// <typeparam name="Station"></typeparam>
        /// <param name="list"></param>
        /// <param name="indexA"></param>
        /// <param name="indexB"></param>
        public static void Swap<Station>(IList<Station> list, int indexA, int indexB)
        {
            Station tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        /// <summary>
        /// The recursive function which tests total distance for all possible permutations 
        /// </summary>
        /// <param name="k"></param>
        /// <param name="A"></param>
        public void Level3Generate(int k, List<Station> A)
        {
            if (k == 1)
            {
                // test to ensure Post Office is at the start
                if (A.ElementAt(0) == START_STATION)
                {
                    // calculate new total distance and test if better
                    float totalDistance = CalcTotalDist(ref A);
                    if (totalDistance < TOTAL_DISTANCE)
                    {
                        // if better create a new tour (this is to ensure no shallow copies are made which caused bugs without)
                        List<Station> newTour = new List<Station>(A.Count);
                        A.ForEach(delegate (Station s)
                        {
                            newTour.Add(s);
                        });
                        // set STATIONS list to the newTour
                        Console.WriteLine($"{totalDistance} {TOTAL_DISTANCE}");
                        STATIONS = newTour;
                        // set TOTAL DISTANCE to our new distance for testing
                        TOTAL_DISTANCE = totalDistance;
                    }
                }
            }
            else
            {
                Level3Generate(k - 1, A);
                for (int i = 0; i < (k - 1); i++)
                {
                    if (k % 2 == 0)
                    {
                        // swaps stations
                        Swap(A, i, k-1);
                    }
                    else
                    {
                        // swaps stations
                        Swap(A, 0, k-1);
                    }
                    Level3Generate(k - 1, A);
                }
            }
        }

        /// <summary>
        /// Calculates Total Distance of list given
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        float CalcTotalDist(ref List<Station> s)
        {
            float distance = 0;
            for (int i = 0; i < s.Count - 1; i++)
            {
                distance += CalcDist(s.ElementAt(i), s.ElementAt(i + 1));
            }
            return distance;
        }

        /// <summary>
        /// Calculates Overall Time of Best Tour as well as Timestamps for Console Write
        /// This happens at the very end to ensure no unnecessary calculations each permutation for Level 1, 2 + 3
        /// </summary>
        public void CalcOverallTimes()
        {
            try
            {
                double range = PLANE_SPECS.GetRange();
                for (int i = 0; i < STATIONS.Count - 1; i++)
                {
                    TimeSpan[] FLIGHTTIMES = new TimeSpan[2];
                    //Calc duration of flight and split to hours and mins
                    float duration = CalcTime(STATIONS.ElementAt(i), STATIONS.ElementAt(i + 1)) / 60;
                    int hours = Convert.ToInt32(Math.Floor(duration));
                    int mins = Convert.ToInt32((duration * 60) % 60);

                    // test if flight is possible on current range
                    if (range - duration < 0)
                    {
                        // add to list of refuel positions and add time.
                        REFUEL_POS.Add(i);
                        range = PLANE_SPECS.GetRange();
                        START_TIME = START_TIME.Add(new TimeSpan(0, Convert.ToInt32(PLANE_SPECS.GetRefuelTime()), 0));
                    }
                    else
                    {
                        range -= duration;
                    }
                    //add the times to the list of timestamps for console write
                    TimeSpan END_TIME = new TimeSpan(hours, mins, 0) + START_TIME;
                    FLIGHTTIMES[0] = START_TIME;
                    FLIGHTTIMES[1] = END_TIME;
                    TIMES.Add(FLIGHTTIMES);
                    START_TIME = END_TIME;
                }
            }
            catch (Exception e)
            {
                Console.Write($"CalculateOverallTimesError: ");
                throw;
            }

        }


        /// <summary>
        /// Function to Write the final Tour of STATIONS to the Console
        /// </summary>
        /// <param name="COMP_TIME"></param>
        public void WriteToConsole(float COMP_TIME)
        {
            try
            {
                // print out necessary statistics of times and distance
                Console.WriteLine($"Elapsed Time: {COMP_TIME / 1000}");
                TimeSpan TOTAL_TIME = TIMES[TIMES.Count - 1][1] - TIMES[0][0];
                Console.WriteLine($"Tour time: {TOTAL_TIME.Days} Days {TOTAL_TIME.Hours} Hours {TOTAL_TIME.Minutes} Minutes");
                Console.WriteLine($"Tour length: {TOTAL_DISTANCE}");
                // iterates over stations
                for (int i = 0; i < STATIONS.Count - 1; i++)
                {
                    // tests if there are refuels necessary
                    if (REFUEL_POS.Contains(i))
                    {
                        Console.WriteLine($"*** refuel {PLANE_SPECS.REFUEL_TIME} mins ***");
                        REFUEL_POS.Remove(i);
                    }
                    // uses StationToStation function to output path
                    Console.WriteLine(StationToStation(i));
                }
            }
            catch (Exception e)
            {
                Console.Write($"WriteToConsoleError: ");
                throw;
            } 
        }

        /// <summary>
        /// Final function to Write the final Tour of STATIONS to the provided txt file (if provided, else disregard) 
        /// </summary>
        /// <param name="FILENAME"></param>
        /// <param name="COMP_TIME"></param>
        public void WriteToTxt(string FILENAME, float COMP_TIME)
        {
            try
            {
                // opens file and writer
                FileStream outFile = new FileStream(FILENAME, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);

                // writes necessary statistics as seen in console
                writer.WriteLine($"Elapsed Time: {COMP_TIME / 1000}");
                TimeSpan TOTAL_TIME = TIMES[TIMES.Count - 1][1] - TIMES[0][0];
                writer.WriteLine($"Tour time: {TOTAL_TIME.Days} Days {TOTAL_TIME.Hours} Hours {TOTAL_TIME.Minutes} Minutes");
                writer.WriteLine($"Tour length: {TOTAL_DISTANCE}");

                // iterates over stations
                for (int i = 0; i < STATIONS.Count - 1; i++)
                {
                    // tests if there is refuels necessary
                    if (REFUEL_POS.Contains(i))
                    {
                        writer.WriteLine($"*** refuel {PLANE_SPECS.REFUEL_TIME} mins ***");
                        REFUEL_POS.Remove(i);
                    }
                    // uses StationToStation function to output path
                    writer.WriteLine(StationToStation(i));
                }
                // close writer and file
                writer.Close();
                outFile.Close();
            } catch (Exception e)
            {
                Console.Write($"WriteToTxtError: in file {FILENAME}");
                Console.WriteLine("Please ensure argument format of 'mail.txt[input stations file] plane.txt[plane spec file] 00:00[time] -o output.txt[optional output file]");
                throw;
            }  
        }

        /// <summary>
        /// Helper for Writing to Console and Txt
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string StationToStation(int i)
        {
            return String.Format($"{$"{STATIONS.ElementAt(i).Name}",-10}->{$"{STATIONS.ElementAt(i + 1).Name}",10}{$"{TIMES.ElementAt(i)[0].ToString(@"hh\:mm")}",10}{$"{TIMES.ElementAt(i)[1].ToString(@"hh\:mm")}",10}");
        }
    }
}

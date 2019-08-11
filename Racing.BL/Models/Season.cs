using System;
using System.Collections.Generic;
using System.Text;

namespace Racing.BL.Models
{
    public class Season
    {
        private readonly int seasonId;

        public Season(int seasonId)
        {
            this.seasonId = seasonId;
        }

        public void CalculateTable(List<Race> seasonRaces, List<SeasonParticipant> seasonParticipants)
        {
            foreach (var seasonRace in seasonRaces)
            {
                foreach (var driver in seasonRace.ListOfParticipants)
                {
                    bool driverAlreadyInTable = false;

                    foreach (var seasonParticipant in seasonParticipants)
                    {
                        if (seasonParticipant.DriverId == driver.DriverId)
                        {
                            driverAlreadyInTable = true;

                            switch (driver.Position)
                            {
                                case 1:
                                    seasonParticipant.Points += 5;
                                    break;
                                case 2:
                                    seasonParticipant.Points += 4;
                                    break;
                                case 3:
                                    seasonParticipant.Points += 3;
                                    break;
                                case 4:
                                    seasonParticipant.Points += 2;
                                    break;
                                case 5:
                                    seasonParticipant.Points += 1;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    if (!driverAlreadyInTable)
                    {
                        SeasonParticipant newSeasonParticipant = new SeasonParticipant(driver);

                        switch (driver.Position)
                        {
                            case 1:
                                newSeasonParticipant.Points += 5;
                                break;
                            case 2:
                                newSeasonParticipant.Points += 4;
                                break;
                            case 3:
                                newSeasonParticipant.Points += 3;
                                break;
                            case 4:
                                newSeasonParticipant.Points += 2;
                                break;
                            case 5:
                                newSeasonParticipant.Points += 1;
                                break;
                            default:
                                break;
                        }

                        seasonParticipants.Add(newSeasonParticipant);
                    }
                }
            }
        }
    }
}

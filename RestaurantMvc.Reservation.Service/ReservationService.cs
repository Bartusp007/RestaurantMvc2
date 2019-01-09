using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantMvc.Data.Infrastructure;
using RestaurantMvc.Data.Repositories;
using RestaurantMvc.Model.Models;
using RestaurantMvc.ViewModel.ViewModels;

namespace RestaurantMvc.Reservation.Service
{

        public class ReservationService : IServiceReservation
        {
            private readonly IReservationsRepository _reservationsRepository;
            private readonly ITableRepository _tableRepository;
            private readonly IUnitOfWork _unitOfWork;

            public ReservationService()
            {
                IDbFactory dbFactory = new DbFactory();
                _reservationsRepository = new ReservationsRepository(dbFactory);
                _tableRepository = new TableRepository(dbFactory);
                _unitOfWork = new UnitOfWork(dbFactory);
            }

            public IEnumerable<Model.Models.Reservation> GetReservationByUserId(string userId)
            {
            
                return _reservationsRepository.GetMany(a => a.UserId == userId);
            }

            public bool ReserveTable(ReservationViewModel reservationData)
            {
                var checkResult = Check(reservationData.UpdatePreReservation());
                if (checkResult.IsAvailable)
                {
                    _reservationsRepository.Add(reservationData.UpdateModel(new Model.Models.Reservation()), checkResult.TableList);
                    _unitOfWork.Commit();
                    return true;
                }
                return false;
            }

            public bool CheckPreReservation(PreReservationViewModel preReservation)
            {
                return Check(preReservation).IsAvailable;
            }

            public StringBuilder DisplayReservation(DateTime date)
            {
                var result = new StringBuilder();
                var listOfReservations = _reservationsRepository.GetManyTables(r => r.ReservationDate == date);
                var numberOfReservations = listOfReservations.Count;
                result.AppendLine($"Rezerwacje w dniu {date.ToString("yyyy mmmm dd")}:");
                result.AppendLine();
                if (numberOfReservations != 0)
                {
                    foreach (var reservation in listOfReservations)
                    {
                        result.AppendLine(
                            $"# Rezerwacja ID:{reservation.Id}, Liczba osób:{reservation.HowManyPeoples}  Stolik/i: {string.Join(",", reservation.Table.Select(table => table.TableId.ToString()))}");
                    }
                }
                else
                {
                    result.AppendLine("Brak rezerwacji.");
                }

                return result;
            }


            public RequestAvaibility Check(PreReservationViewModel preReservation)
            {
                var result = new RequestAvaibility();
                var freeTables = GetAvailable(preReservation);
                AddTables(ref freeTables, preReservation.HowManyPeoples, ref result);
                return result;
            }

            public static void AddTables(ref List<Table> freeTables, int ammountOfPeople, ref RequestAvaibility result)
            {
                if (ammountOfPeople > 0)
                {
                    var exactAmount = freeTables.FirstOrDefault(ft => ft.Capacity == ammountOfPeople);
                    if (exactAmount != null)
                    {
                        result.IsAvailable = true;
                        result.TableList.Add(exactAmount);
                        ammountOfPeople = 0;
                        AddTables(ref freeTables, ammountOfPeople, ref result);
                    }
                    else
                    {
                        var totalCapacity = freeTables.Sum(ft => ft.Capacity);
                        if (totalCapacity < ammountOfPeople)
                        {
                            result.IsAvailable = false;
                            ammountOfPeople = 0;
                            AddTables(ref freeTables, ammountOfPeople, ref result);
                        }
                        else
                        {
                            var biggerTable = freeTables.Where(ft => ft.Capacity > ammountOfPeople)
                                .OrderBy(ft => ft.Capacity).FirstOrDefault();
                            if (biggerTable != null)
                            {
                                result.IsAvailable = true;
                                result.TableList.Add(biggerTable);
                                freeTables.Remove(biggerTable);
                                ammountOfPeople = ammountOfPeople - biggerTable.Capacity;
                                AddTables(ref freeTables, ammountOfPeople, ref result);
                            }
                            else
                            {
                                result.IsAvailable = true;
                                var table = freeTables.OrderByDescending(ft => ft.Capacity).FirstOrDefault();
                                result.TableList.Add(table);
                                freeTables.Remove(table);
                                ammountOfPeople = ammountOfPeople - table.Capacity;
                                AddTables(ref freeTables, ammountOfPeople, ref result);
                            }
                        }
                    }
                }
            }




            public List<Table> GetAvailable(PreReservationViewModel preReservation)
            {
                var tables = _tableRepository.TablesEager().GetFree(preReservation);
                return tables;
            }
        }
    }

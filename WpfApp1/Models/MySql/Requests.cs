using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WpfApp1.Models.Car;
using WpfApp1.Models.MySql;
using WpfApp1.Models.User;

namespace WpfApp1
{
    public class Requests
    {
        private string GetConnectionString(string path)
        {
            ConnectionStringMySql connectionString = new ConnectionStringMySql();
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadLine();
                connectionString = JsonSerializer.Deserialize<ConnectionStringMySql>(json);
            }

            return connectionString.ConnectionString;
        }

        public List<Car> GetAllFreeCars()
        {
            List<Car> cars = new List<Car>();
            string connectionString = GetConnectionString(@"..\Connection\ConnectionString.json");
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string sql = "select CarId, CarDescription, MainImageCar, Images, PricePerDay, Availability, " +
                "CarPassport.CarPassportId, CarPassport.CarName, CarPassport.CarBrand, CarPassport.CarCategory, " +
                "CarPassport.CarPower, CarPassport.CountryOfOrigin, CarPassport.DateRelease from `Cars`, `CarPassport` " +
                "where Cars.CarPassportId = CarPassport.CarPassportId and Cars.Availability = 0";

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string[] images = Convert.ToString(reader[3]).Split(';');

                cars.Add(new Car()
                {
                    CarId = Convert.ToInt32(reader[0]),
                    CarDescription = Convert.ToString(reader[1]),
                    MainImageCar = Convert.ToString(reader[2]),
                    PricePerDay = Convert.ToInt32(reader[4]),
                    Availability = Convert.ToBoolean(reader[5]),
                    Images = images.Where(i => i != "").ToList(),
                    Passport = new CarPassport()
                    {
                        Id = Convert.ToInt32(reader[6]),
                        CarName = Convert.ToString(reader[7]),
                        CarBrand = Convert.ToString(reader[8]),
                        CarCategory = Convert.ToString(reader[9]),
                        Power = Convert.ToInt32(reader[10]),
                        CountryOfOrigin = Convert.ToString(reader[11]),
                        YearRelease = Convert.ToDateTime(reader[12]),
                    }
                });
            }
            reader.Close();
            connection.Close();

            return cars;
        }

        public User GetUser(string loginOrEmail, string password)
        {
            User user = new User();

            string connectionString = GetConnectionString(@"..\Connection\ConnectionString.json");
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string sql = $"select UserId, UserLogin, UserPassword, UserEmail, PassportUsers.PassportId, PassportUsers.Firstname," +
                $" PassportUsers.MiddleName, PassportUsers.LastName, PassportUsers.Series, PassportUsers.Number," +
                $" PassportUsers.DateBirthday from Users, PassportUsers where Users.UserPassportId = PassportUsers.PassportId" +
                $" and (Users.UserLogin = '{loginOrEmail}' or Users.UserEmail = '{loginOrEmail}') and Users.UserPassword = '{password}';";

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                user.UserId = Convert.ToInt32(reader[0]);
                user.Login = Convert.ToString(reader[1]);
                user.Password = Convert.ToString(reader[2]);
                user.Email = Convert.ToString(reader[3]);
                user.UserPassport = new Passport()
                {
                    Id = Convert.ToInt32(reader[4]),
                    FirstName = Convert.ToString(reader[5]),
                    MiddleName = Convert.ToString(reader[6]),
                    LastName = Convert.ToString(reader[7]),
                    Series = Convert.ToInt32(reader[8]),
                    Number = Convert.ToInt32(reader[9]),
                    DateBirthday = Convert.ToDateTime(reader[10]),
                };
            }

            reader.Close();
            connection.Close();
            
            return user;
        }

        public void CarBooking(User user, Car car, float totalPrice, DateTime startDate, DateTime endDate)
        {
            string connectionString = GetConnectionString(@"..\Connection\ConnectionString.json");
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string sql = $"insert into Bookings(UserId, CarId, StartDate, EndDate, TotalPrice, BookingStatus) VALUES" +
                $" ({user.UserId}, {car.CarId}, '{startDate.Date.ToString("yyyy-MM-dd")}', '{endDate.Date.ToString("yyyy-MM-dd")}', {totalPrice}, 'Бронировано')";

            string sql2 = $"update Cars set Availability = 1 where CarId = {car.CarId}";

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            reader.Close();

            command = new MySqlCommand(sql2, connection);
            reader = command.ExecuteReader();

            reader.Close();
            connection.Close();
        }

        public List<Car> GetReservedCars(User user)
        {
            List<Car> reservedCars = new List<Car>();
            string connectionString = GetConnectionString(@"..\Connection\ConnectionString.json");
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string sql = "select Cars.MainImageCar, CarPassport.CarName, CarPassport.CarBrand, CarPassport.CarCategory," +
                $" CarPassport.CarPower from Bookings, Cars, CarPassport where UserId = {user.UserId} and Bookings.CarId = Cars.CarId" +
                " and Cars.CarPassportId = CarPassport.CarPassportId;";

            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                reservedCars.Add(new Car()
                {
                    MainImageCar = Convert.ToString(reader[0]),
                    Passport = new CarPassport()
                    {
                        CarName = Convert.ToString(reader[1]),
                        CarBrand = Convert.ToString(reader[2]),
                        CarCategory = Convert.ToString(reader[3]),
                        Power = Convert.ToInt32(reader[4])
                    }
                });
            }

            reader.Close();
            connection.Close();

            return reservedCars;
        }
    }
}

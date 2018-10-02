using System;

namespace FluentBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            House fluentHouse = new House.Builder()
                .Floors(3)
                .Bedrooms(4)
                .HasKitchen()
                .HasLivingRoom()
                .Roof("Metal")
                .Build();

            WriteHouse(fluentHouse);

            House ctorHouse = new House(floors: 3, 
                kitchen: true, livingroom: true, roof: "Metal");

            WriteHouse(ctorHouse);
            Console.ReadKey();
        }

        static void WriteHouse(House house)
        {
            Console.WriteLine($"Floors: {house.Floors}");
            Console.WriteLine($"Bedrooms: {house.Bedrooms}");
            Console.WriteLine($"Kitchen: {house.Kitchen}");
            Console.WriteLine($"Living Room: {house.LivingRoom}");
            Console.WriteLine($"Roof: {house.Roof}");
            Console.WriteLine(new string('-', 20));
        }

    }

    public class House
    {
        public int Floors { get; set; }
        public int Bedrooms { get; set; }
        public bool LivingRoom { get; set; }
        public bool Kitchen { get; set; }
        public string Roof { get; set; }

        public House()
        {

        }


        public House(int floors = 0, int bedrooms = 0, bool livingroom= false, bool kitchen = false, string roof = "")
        {
            this.Floors = floors;
            this.Bedrooms = bedrooms;
            this.LivingRoom = livingroom;
            this.Kitchen = kitchen;
            this.Roof = roof;
        }

        public class Builder
        {
            public int floors;
            public int bedrooms;
            public bool livingroom;
            public bool kitchen;
            public string roof;

            public Builder Floors(int value)
            {
                this.floors = value;
                return this;
            }

            public Builder Bedrooms(int value)
            {
                this.bedrooms = value;
                return this;
            }

            public Builder HasLivingRoom()
            {
                this.livingroom = true;
                return this;
            }
            public Builder HasKitchen()
            {
                this.kitchen = true;
                return this;
            }

            public Builder Roof(string value)
            {
                this.roof = value;
                return this;
            }

            public House Build()
            {
                var house = new House();
                house.Floors = this.floors;
                house.Bedrooms = this.bedrooms;
                house.LivingRoom = this.livingroom;
                house.Kitchen = this.kitchen;
                house.Roof = this.roof;
                return house;
            }
        }
    }

}

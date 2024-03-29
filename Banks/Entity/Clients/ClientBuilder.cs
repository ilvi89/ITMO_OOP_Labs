﻿namespace Banks.Entity.Clients
{
    public class ClientBuilder
    {
        private string _id;
        private string _name;
        private string _passport;
        private string _surname;

        public ClientBuilder SetId(string id)
        {
            _id = id;
            return this;
        }

        public ClientBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ClientBuilder SetSurname(string surname)
        {
            _surname = surname;
            return this;
        }

        public ClientBuilder SetPassport(string passport)
        {
            _passport = passport;
            return this;
        }

        public Client GetClient()
        {
            return new Client(_id, _name, _surname, _passport);
        }
    }
}
using AspDotNetStarter.Domain;
using System;

namespace AspDotNetStarter
{
    public class Player : DatabaseEntity
    {
        private string _firstName;
        private string _lastName;
        private int _age;

        public Player()
        {
        }

        public Player(string _id, string _firstName, string _lastName, int _age) : base(_id)
        {
            this._id = _id;
            this._firstName = _firstName;
            this._lastName = _lastName;
            this._age = _age;
        }


        public string FirstName { get => this._firstName; set => this._firstName = value; }

        public string LastName { get => this._lastName; set => this._lastName = value; }

        public int Age { get => this._age; set => this._age = value; }
    }
}

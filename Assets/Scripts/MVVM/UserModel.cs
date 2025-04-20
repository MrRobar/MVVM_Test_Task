using System;

namespace MVVM
{
    [Serializable]
    public class UserModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        public void SetName(string name)
        {
            Name = name;
        }
        
        public void SetAge(int age)
        {
            Age = age;
        }
    }
}
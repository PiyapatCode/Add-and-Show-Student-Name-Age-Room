using System;
namespace Studentpro {
    class StorageStudentInfo {
   public string Name { get; set; }
        public int Age { get; set; }
        public string Room { get; set; }
        public StorageStudentInfo() { }
        public StorageStudentInfo(string name, int age, string room) {
            Name = name;
            Age = age;
            Room = room;
        
        }
        
    }
}
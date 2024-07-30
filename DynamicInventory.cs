using System.Security.Cryptography;

namespace HW
{
    internal class DynamicInventory
    {
        public class Item
        {
            protected string name;
            public string GetName
            {
                get { return name; }

            }
            public class Inventory
            {
                public List<Item> items = new List<Item>(9);

            }
            public class Potion : Item
            {
                // int recoveryAmount;

                public Potion(string name)
                {
                    // this.recoveryAmount = recoveryAmount;
                    this.name = name;
                }


            }
            public class Weapon : Item
            {
                // int attackPoint;
                public Weapon(string name)
                {
                    // this.attackPoint = attackPoint;
                    this.name = name;
                }

            }
            public class Armor : Item
            {
                // int defensePoint;
                public Armor(string name)
                {
                    // this.defensePoint = defensePoint;
                    this.name = name;
                }

            }

            public class Accessory : Item
            {
                // string ability;

                public Accessory(string name)
                {
                    // this.ability = ability;
                    this.name = name;
                }
            }
            public class Food : Item
            {
                // int fullness;
                public Food(string name)
                {
                    // this.fullness = fullness;
                    this.name = name;
                }
            }

            static void Main1(string[] args)
            {

                Inventory inventory = new Inventory();
                int num;
                bool toDetermine;
                //inventory.items[8] = new Potion(10, "회복포션");
                // inventory.items.Add(new Potion(10, "회복포션")); // 아이템 넣기
                //Potion potion = new Potion();
                //potion.name = "a";
                while (true)
                {
                    int count = 1;
                    Console.WriteLine("현재 인벤토리");
                    foreach (Item item in inventory.items)
                    {
                        
                        Console.WriteLine($"{count} : {item.name}");
                        count++;
                    }

                    Console.WriteLine("아이템을 추가하려면 숫자0을, 아이템을 삭제하려면 아이템의 번호를 눌러주세요.");
                    toDetermine = int.TryParse(Console.ReadLine(), out num);

                    if (inventory.items.Count >= 9 && num==0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("더이상 추가 불가"); //추가 불가능하다도 해야함
                        Console.ResetColor();
                        continue;
                    }

                    if (num == 0)
                    {
                        AddItem(inventory, CreateItem());
                    }
                    else if (inventory.items[num-1] == null) // null조차 아니라 공간 자체가 할당 안되서 안됨
                    {
                        Console.WriteLine("그 공간은 이미 비었습니다."); 
                        continue;
                    }
                    // { num == 0} ? AddItem(inventory, CreateItem()); //값을 반환할 변수가 있어야함

                    if (toDetermine == false || (num > 9 && num < 0)) //아이템이 없는 경우는 나중에 뭔가 조건이 이상함
                    {
                        Console.WriteLine("잘못된 입력");
                        continue;
                    }                    
                    else if (num > 0 && num < 9)
                    {
                        Console.WriteLine($"{num}번째 아이템 {inventory.items[num - 1].name} 을 버렸습니다.");
                        RemoveItem(inventory, num);
                    }
                    
                    // object result = inventory.items[num] ?? AddItem(inventory, CreateItem()) ; 
                    // AddItem(inventory, CreateItem());                    
                }
            }

            static public void AddItem(Inventory _inventory, Item _item)
            {
                _inventory.items.Add(_item);
            }
            static public void RemoveItem(Inventory _inventory, int _num)
            {
                _inventory.items.RemoveAt(_num-1);
            }
            static public Item CreateItem()
            {
                Random rand = new Random();
                int randNum = rand.Next(0, 5);
                // 5개의 아이템 중 랜덤으로 만들기
                switch (randNum)
                {
                    case 0:
                        return new Potion("포션");
                    case 1:
                        return new Weapon("무기");
                    case 2:
                        return new Armor("갑옷");
                    case 3:
                        return new Accessory("장신구");
                    case 4:
                        return new Food("음식");
                    default:
                        Console.WriteLine("입력 에러");
                        return new Item(); // 이러면 안되는데 Item을 return 안하고 강제 종료시킬 순 없나?
                        
                }
            }




        }

    }


}


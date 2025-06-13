namespace search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region task
            List<int> list = [];
            Console.WriteLine("enter the size of the list");
            int size = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"enter the element num{i + 1}");
                list.Add(Convert.ToInt32(Console.ReadLine()));
            }
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        throw new Exception("Duplicate names found");
                    }
                }
            }
            #endregion 

            voewls("mario");
        }
      static  void voewls(string words)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            words = words.ToLower();
            bool flag = false;
            for (int i = 0; i<words.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (words[i] == vowels[j])
                    {
                        flag = true;
                    }
                }
            }
            if (flag == false)
            {
                throw new Exception("The string does not contain any vowels.");
            }
            else
            {
                Console.WriteLine("done");
            }
        }
    }
}

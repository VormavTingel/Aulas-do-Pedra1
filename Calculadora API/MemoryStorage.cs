namespace Calculadora_API
{
    public class MemoryStorage
    {
        private static MemoryStorage instance;
        public double? M1;
        public double? M2;
        public double? M3;
        private MemoryStorage()
        {
            
        }

        public static MemoryStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MemoryStorage();
                }
                return instance;
            }
        }
    }
}

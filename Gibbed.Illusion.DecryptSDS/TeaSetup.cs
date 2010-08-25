namespace Gibbed.Illusion.DecryptSDS
{
    public class TeaSetup
    {
        public uint Sum;
        public uint Delta;
        public uint Rounds;

        public TeaSetup(uint sum, uint delta, uint rounds)
        {
            this.Sum = sum;
            this.Delta = delta;
            this.Rounds = rounds;
        }
    }
}

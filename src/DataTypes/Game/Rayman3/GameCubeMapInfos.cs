namespace BinarySerializer.Ubisoft.GbaEngine.Rayman3
{
    public class GameCubeMapInfos : BinarySerializable
    {
        public int MapsCount { get; set; }
        public GameCubeMapInfo[] Maps { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            MapsCount = s.Serialize<int>(MapsCount, name: nameof(MapsCount));
            Maps = s.SerializeObjectArray<GameCubeMapInfo>(Maps, MapsCount, name: nameof(Maps));
        }
    }
}

namespace BinarySerializer.Ubisoft.GbaEngine.Rayman3
{
    public class GameCubeMap : BinarySerializable
    {
        public int SceneLength { get; set; }
        public Scene2D Scene { get; set; }

        public int PlayfieldLength { get; set; }
        public Playfield Playfield { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            SceneLength = s.Serialize<int>(SceneLength, name: nameof(SceneLength));
            Scene = s.SerializeObject<Scene2D>(Scene, x => x.Pre_IsGameCubeResource = true, name: nameof(Scene));

            s.Goto(Offset + SceneLength);
            PlayfieldLength = s.Serialize<int>(PlayfieldLength, name: nameof(PlayfieldLength));
            Playfield = s.SerializeObject<Playfield>(Playfield, x => x.Pre_IsGameCubeResource = true, name: nameof(Playfield));
        }
    }
}
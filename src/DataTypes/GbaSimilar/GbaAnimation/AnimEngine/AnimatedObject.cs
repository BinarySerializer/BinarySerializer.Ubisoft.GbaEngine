﻿namespace BinarySerializer.Ubisoft.GbaEngine
{
    public class AnimatedObject : Resource
    {
        public ushort SpriteTableLength { get; set; }
        public byte Idx_SpriteTable { get; set; }
        public byte Idx_Palette { get; set; }
        public byte PalettesCount { get; set; }
        public bool Is8Bit { get; set; }
        public bool IsDynamic { get; set; }
        public byte AnimationsCount { get; set; }
        public byte MaxChannelsPerFrame { get; set; }
        public byte[] Idx_Animations { get; set; }

        // Dependencies
        public SpritePalettes Palettes { get; set; }
        public SpriteTable SpriteTable { get; set; }
        public Animation[] Animations { get; set; }

        public override void SerializeResource(SerializerObject s)
        {
            GbaEngineSettings settings = s.GetRequiredSettings<GbaEngineSettings>();

            if (settings.Game is not (
                Game.Rayman3_20020118_DemoRLE or 
                Game.Rayman3_20020301_PreAlpha or 
                Game.Rayman3_20020418_NintendoE3Approval or 
                Game.Rayman3_20020513_E3GameCube))
                SpriteTableLength = s.Serialize<ushort>(SpriteTableLength, name: nameof(SpriteTableLength));
            
            Idx_SpriteTable = s.Serialize<byte>(Idx_SpriteTable, name: nameof(Idx_SpriteTable));
            Idx_Palette = s.Serialize<byte>(Idx_Palette, name: nameof(Idx_Palette));
            s.DoBits<byte>(b =>
            {
                PalettesCount = b.SerializeBits<byte>(PalettesCount, 4, name: nameof(PalettesCount));
                Is8Bit = b.SerializeBits<bool>(Is8Bit, 1, name: nameof(Is8Bit));
                IsDynamic = b.SerializeBits<bool>(IsDynamic, 1, name: nameof(IsDynamic));
                b.SerializePadding(2, logIfNotNull: true);
            });
            AnimationsCount = s.Serialize<byte>(AnimationsCount, name: nameof(AnimationsCount));
            
            if (settings.Game is not (Game.Rayman3_20020118_DemoRLE or Game.Rayman3_20020301_PreAlpha))
                MaxChannelsPerFrame = s.Serialize<byte>(MaxChannelsPerFrame, name: nameof(MaxChannelsPerFrame));
            
            Idx_Animations = s.SerializeArray<byte>(Idx_Animations, AnimationsCount, name: nameof(Idx_Animations));
        }

        public override void SerializeDependencies(SerializerObject s)
        {
            Palettes = SerializeDependency<SpritePalettes>(s, Palettes, Idx_Palette, onPreSerialize: x =>
            {
                x.Pre_Is8Bit = Is8Bit;
                x.Pre_PalettesCount = PalettesCount;
            }, name: nameof(Palettes));
            SpriteTable = SerializeDependency<SpriteTable>(s, SpriteTable, Idx_SpriteTable, onPreSerialize: x =>
            {
                x.Pre_IsDynamic = IsDynamic;
            }, name: nameof(SpriteTable));

            Animations = SerializeDependencyArray<Animation>(s, Animations, Idx_Animations, name: nameof(Animations));

            foreach (Animation animation in Animations)
            {
                if (animation.Idx_AffineMatrices != 0)
                    animation.AffineMatrices = SerializeDependency<AffineMatrices>(s, animation.AffineMatrices, animation.Idx_AffineMatrices, name: nameof(animation.AffineMatrices));

                if (animation.Idx_PaletteCycleAnimation != 0)
                    animation.PaletteCycleAnimation = SerializeDependency<PaletteCycleAnimation>(s, animation.PaletteCycleAnimation, animation.Idx_PaletteCycleAnimation, name: nameof(animation.PaletteCycleAnimation));
            }
        }
    }
}
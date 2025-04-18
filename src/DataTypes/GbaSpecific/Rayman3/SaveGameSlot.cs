﻿namespace BinarySerializer.Ubisoft.GbaEngine.Rayman3
{
    public class SaveGameSlot : BinarySerializable
    {
        public byte[] Lums { get; set; }
        public byte[] Cages { get; set; }

        public byte LastPlayedLevel { get; set; }
        public byte LastCompletedLevel { get; set; }
        public byte Lives { get; set; }

        public bool FinishedLyChallenge1 { get; set; }
        public bool FinishedLyChallenge2 { get; set; }
        public bool FinishedLyChallengeGCN { get; set; }

        public bool UnlockedBonus1 { get; set; }
        public bool UnlockedBonus2 { get; set; }
        public bool UnlockedBonus3 { get; set; }
        public bool UnlockedBonus4 { get; set; }

        public bool UnlockedWorld2 { get; set; }
        public bool UnlockedWorld3 { get; set; }
        public bool UnlockedWorld4 { get; set; }

        public bool PlayedWorld2Unlock { get; set; }
        public bool PlayedWorld3Unlock { get; set; }
        public bool PlayedWorld4Unlock { get; set; }

        public bool PlayedAct4 { get; set; }
        public bool PlayedMurfyWorldHelp { get; set; }
        public bool UnlockedFinalBoss { get; set; }
        public bool UnlockedLyChallengeGCN { get; set; }

        public byte CompletedGCNBonusLevels { get; set; }

        public override void SerializeImpl(SerializerObject s)
        {
            GbaEngineSettings settings = s.GetRequiredSettings<GbaEngineSettings>();

            Lums = s.SerializeArray<byte>(Lums, 125, name: nameof(Lums));
            Cages = s.SerializeArray<byte>(Cages, 7, name: nameof(Cages));
            LastPlayedLevel = s.Serialize<byte>(LastPlayedLevel, name: nameof(LastPlayedLevel));
            LastCompletedLevel = s.Serialize<byte>(LastCompletedLevel, name: nameof(LastCompletedLevel));
            Lives = s.Serialize<byte>(Lives, name: nameof(Lives));

            if (settings.Game == Game.Rayman3_Prototype)
            {
                s.DoBits<byte>(b =>
                {
                    FinishedLyChallenge1 = b.SerializeBits<bool>(FinishedLyChallenge1, 1, name: nameof(FinishedLyChallenge1));
                    FinishedLyChallenge2 = b.SerializeBits<bool>(FinishedLyChallenge2, 1, name: nameof(FinishedLyChallenge2));
                    UnlockedBonus1 = b.SerializeBits<bool>(UnlockedBonus1, 1, name: nameof(UnlockedBonus1));
                    UnlockedBonus2 = b.SerializeBits<bool>(UnlockedBonus2, 1, name: nameof(UnlockedBonus2));
                    UnlockedBonus3 = b.SerializeBits<bool>(UnlockedBonus3, 1, name: nameof(UnlockedBonus3));
                    UnlockedBonus4 = b.SerializeBits<bool>(UnlockedBonus4, 1, name: nameof(UnlockedBonus4));
                    UnlockedWorld2 = b.SerializeBits<bool>(UnlockedWorld2, 1, name: nameof(UnlockedWorld2));
                    UnlockedWorld3 = b.SerializeBits<bool>(UnlockedWorld3, 1, name: nameof(UnlockedWorld3));
                });
                s.DoBits<byte>(b =>
                {
                    UnlockedWorld4 = b.SerializeBits<bool>(UnlockedWorld4, 1, name: nameof(UnlockedWorld4));
                    PlayedWorld2Unlock = b.SerializeBits<bool>(PlayedWorld2Unlock, 1, name: nameof(PlayedWorld2Unlock));
                    PlayedWorld3Unlock = b.SerializeBits<bool>(PlayedWorld3Unlock, 1, name: nameof(PlayedWorld3Unlock));
                    PlayedWorld4Unlock = b.SerializeBits<bool>(PlayedWorld4Unlock, 1, name: nameof(PlayedWorld4Unlock));
                    PlayedAct4 = b.SerializeBits<bool>(PlayedAct4, 1, name: nameof(PlayedAct4));
                    PlayedMurfyWorldHelp = b.SerializeBits<bool>(PlayedMurfyWorldHelp, 1, name: nameof(PlayedMurfyWorldHelp));
                    b.SerializePadding(2, logIfNotNull: true);
                });
                CompletedGCNBonusLevels = s.Serialize<byte>(CompletedGCNBonusLevels, name: nameof(CompletedGCNBonusLevels));
            }
            else
            {
                s.DoBits<byte>(b =>
                {
                    FinishedLyChallenge1 = b.SerializeBits<bool>(FinishedLyChallenge1, 1, name: nameof(FinishedLyChallenge1));
                    FinishedLyChallenge2 = b.SerializeBits<bool>(FinishedLyChallenge2, 1, name: nameof(FinishedLyChallenge2));
                    FinishedLyChallengeGCN = b.SerializeBits<bool>(FinishedLyChallengeGCN, 1, name: nameof(FinishedLyChallengeGCN));
                    UnlockedBonus1 = b.SerializeBits<bool>(UnlockedBonus1, 1, name: nameof(UnlockedBonus1));
                    UnlockedBonus2 = b.SerializeBits<bool>(UnlockedBonus2, 1, name: nameof(UnlockedBonus2));
                    UnlockedBonus3 = b.SerializeBits<bool>(UnlockedBonus3, 1, name: nameof(UnlockedBonus3));
                    UnlockedBonus4 = b.SerializeBits<bool>(UnlockedBonus4, 1, name: nameof(UnlockedBonus4));
                    UnlockedWorld2 = b.SerializeBits<bool>(UnlockedWorld2, 1, name: nameof(UnlockedWorld2));
                });
                s.DoBits<byte>(b =>
                {
                    UnlockedWorld3 = b.SerializeBits<bool>(UnlockedWorld3, 1, name: nameof(UnlockedWorld3));
                    UnlockedWorld4 = b.SerializeBits<bool>(UnlockedWorld4, 1, name: nameof(UnlockedWorld4));
                    PlayedWorld2Unlock = b.SerializeBits<bool>(PlayedWorld2Unlock, 1, name: nameof(PlayedWorld2Unlock));
                    PlayedWorld3Unlock = b.SerializeBits<bool>(PlayedWorld3Unlock, 1, name: nameof(PlayedWorld3Unlock));
                    PlayedWorld4Unlock = b.SerializeBits<bool>(PlayedWorld4Unlock, 1, name: nameof(PlayedWorld4Unlock));
                    PlayedAct4 = b.SerializeBits<bool>(PlayedAct4, 1, name: nameof(PlayedAct4));
                    PlayedMurfyWorldHelp = b.SerializeBits<bool>(PlayedMurfyWorldHelp, 1, name: nameof(PlayedMurfyWorldHelp));
                    UnlockedFinalBoss = b.SerializeBits<bool>(UnlockedFinalBoss, 1, name: nameof(UnlockedFinalBoss));
                });
                s.DoBits<byte>(b =>
                {
                    UnlockedLyChallengeGCN = b.SerializeBits<bool>(UnlockedLyChallengeGCN, 1, name: nameof(UnlockedLyChallengeGCN));
                    b.SerializePadding(7, logIfNotNull: true);
                });
                CompletedGCNBonusLevels = s.Serialize<byte>(CompletedGCNBonusLevels, name: nameof(CompletedGCNBonusLevels));
            }
        }
    }
}

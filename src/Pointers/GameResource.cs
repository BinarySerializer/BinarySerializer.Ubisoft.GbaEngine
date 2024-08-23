namespace BinarySerializer.Ubisoft.GbaEngine
{
    public enum GameResource
    {
        [GameResourceDefine(Game.Rayman3, Platform.GBA, 65)]
        SoundBank,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 67)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 71)]
        Player4RaymanPalette,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 68)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 72)]
        Player2RaymanPalette,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 69)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 73)]
        Player3RaymanPalette,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 70)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 79)]
        HudAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 80)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 91)]
        TimerAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 81)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 92)]
        LevelDashboardAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 84)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 95)]
        SwitchBarAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 85)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 96)]
        PauseSelectionAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 86)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 97)]
        PauseCanvasAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 88)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 99)]
        BossMachineBarAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.NGage, 102)]
        CaptureTheFlagArrowAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 91)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 103)]
        MenuPlayfield,

        [GameResourceDefine(Game.Rayman3, Platform.NGage, 104)]
        NGageButtonSymbols,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 92)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 105)]
        MenuPropAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 93)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuStartEraseAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 95)]
        GameCubeMenuAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 96)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuGameLogoAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 97)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuGameModeAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 98)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuLanguageListAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 99)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuOptionsAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 100)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuSlotEmptyAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 101)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuMultiplayerModeAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 102)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuMultiplayerPlayersAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 105)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuSteamAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 106)]
        GameCubeMenuLevelCheckAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 109)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 123)]
        GameOverRaymanAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 110)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 124)]
        GameOverCountdownAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 111)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 125)]
        GameOverButterflyAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 112)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 126)]
        TextBoxCanvasAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 113)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 127)]
        TextBoxRaymanIconAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 114)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 128)]
        TextBoxLyIconAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 115)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 129)]
        TextBoxMurfyIconAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 116)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 130)]
        TextBoxTeensiesIconAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 117)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 131)]
        IntroPlayfield,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 118)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 132)]
        IntroAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 123)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 137)]
        FogAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 124)]
        WorldCurtainAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 125)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 139)]
        StoryNextTextAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.NGage, 143)]
        GameOverBitmap,

        [GameResourceDefine(Game.Rayman3, Platform.NGage, 165)]
        GameOverPalette,

        [GameResourceDefine(Game.Rayman3, Platform.NGage, 187)]
        Font8,

        [GameResourceDefine(Game.Rayman3, Platform.NGage, 188)]
        Font16,

        [GameResourceDefine(Game.Rayman3, Platform.NGage, 189)]
        Font32,
    }
}
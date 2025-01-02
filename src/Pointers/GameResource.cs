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

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 71)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 80)]
        WorldDashboardAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 72)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 81)]
        BlueLumBarAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 73)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 82)]
        MultiplayerCountdownAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 74)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 83)]
        MultiplayerTimerAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 75)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 84)]
        MultiplayerIconAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 76)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 85)]
        MultiplayerItemAnimations,
        
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 86)]
        NGageMultiplayerPauseSignAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 77)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 87)]
        MultiplayerGameOverSignAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.NGage, 88)]
        NGageMultiplayerSuddenDeathSignAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 78)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 89)]
        MultiplayerPlayerIconAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 79)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 90)]
        MultiplayerRankAnimations,

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
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 106)]
        MenuStartEraseAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 94)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuMultiplayerTypeFrameAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 95)]
        GameCubeMenuAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 96)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 109)]
        MenuGameLogoAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 97)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 110)]
        MenuGameModeAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 98)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 111)]
        MenuLanguageListAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 99)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 112)]
        MenuOptionsAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 100)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 113)]
        MenuSlotEmptyAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 101)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuMultiplayerModeAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 102)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuMultiplayerPlayersAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 103)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuMultiplayerTypeAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 104)]
        //[GameResourceDefine(Game.Rayman3, Platform.NGage, )]
        MenuMultiplayerMapAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 105)]
        MenuSteamAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 106)]
        GameCubeMenuLevelCheckAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 108)]
        MenuMultiplayerTypeIconAnimations,

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

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 121)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 135)]
        RaymanWorldMapAnimations,

        [GameResourceDefine(Game.Rayman3, Platform.GBA, 122)]
        [GameResourceDefine(Game.Rayman3, Platform.NGage, 136)]
        WorldMapPathAnimations,

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
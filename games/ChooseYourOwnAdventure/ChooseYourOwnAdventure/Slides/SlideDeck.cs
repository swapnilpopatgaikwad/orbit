﻿using BuildingGames.Slides.Accessibility;
using BuildingGames.Slides.Gaming;
using BuildingGames.Slides.Tutorials;
using BuildingGames.Slides.Voting;

namespace BuildingGames.Slides;

public static class SlideDeck
{
    // TODO: encapsulate this nicely to handle the branches and general navigation flow.
	public static IList<Type> Slides { get; } = new List<Type>()
    {
        // typeof(DuckTypingScene),
        // typeof(TitleScene),
        // typeof(CharacterSelectionScene),
        // typeof(PrologueScene),
        // typeof(WorldScene),
        // typeof(TutorialScene),

        // // What is powering the talk today?
        // typeof(TheGameEngineApproachScene),
        // typeof(ProcessUserInputScene),
        // //typeof(ProcessUserInputPartTwoScene), - voting option?
        // typeof(UpdateScene),
        // typeof(RenderScene),
        // typeof(WaitScene), // 14 minutes

        // // Decision 1 - would you like to learn about the general concepts of what a game engine is?
        // typeof(DecisionTime1Scene),

        // // Option 1
        // typeof(VotingTutorial1Scene),

        // // WHY USE BACKGROUND SERVICE??
        // // Option 2
        // typeof(GamingTutorial0Scene),
        // typeof(GamingTutorial1Scene),
        // typeof(TutorialPartTwoScene),
        typeof(TutorialPartThreeScene),
        typeof(GamingTutorial2Scene),
        typeof(GamingTutorial3Scene),
        typeof(GamingTutorial4Scene),
        typeof(GamingTutorial5Scene),
        typeof(GamingTutorial6Scene),
        typeof(GamingTutorial7Scene),
        typeof(GamingTutorialDemoScene),
        typeof(GamingTutorialWrapUp1Scene),
        typeof(GamingTutorialWrapUp2Scene),

        // // Summarise this point
        // typeof(Stage1SummaryScene),

        typeof(WorldScene),

        // // Decision Time
        // typeof(MagicianScene),
        // //typeof(ChooseDifficultyScene), // Maybe offer a slight detour on our journey to learn these things?
        // //typeof(RedVersusBluePillScene), // SlideLottie or TheGameEngineApproachScene

        // // Optional extra from MagicianScene - might not fit but it offers some nice insights.
        // typeof(SlideLottie),
        // typeof(SlideAnimations),
        // typeof(SlideAnimationsPartTwo),
        // typeof(SlideParticleEffects),
        // typeof(SlideCombined), // Roughly 5 minutes

        // What is powering the talk today?

        // Decision deep dive into Orbit game or look at the engine behind it?
        typeof(OrbitGameOrOrbitEngineScene),
        typeof(GameDemoScene),

        // Decision to look at code behind this or accessibility? - Perhaps make it simple for you or the user?

        typeof(HowToUsePartOne),
        typeof(HowToUsePartTwo),
        typeof(HowToUsePartThree),
        typeof(HowToUsePartFour),
        typeof(HowToUsePartFive),

        typeof(TipsAndTricksSimpleScene),
        typeof(TipsAndTricksSimplePartTwoScene),
        typeof(TipsAndTricksDeviceScene),

        typeof(TheFinalBossScene),
        typeof(SummaryScene),
        typeof(Credits)
    };

    private static int currentSlideIndex = 0;

    public static Type CurrentSlideType => Slides[currentSlideIndex];

    public static event Action<string> SlideNotesChanged;
    public static event Action<Type> SlideChanged;

    public static int GetSlideIndex(Type type) => Slides.IndexOf(type) + 1;

    public static void SetSlideNotes(string notes)
    {
        SlideNotesChanged?.Invoke(notes);
    }

    public static void SetCurrentSlideType(Type type)
    {
        currentSlideIndex = Slides.IndexOf(type);

        SlideChanged?.Invoke(Slides[currentSlideIndex]);
    }

    public static Type GetNextSlideType()
    {
        var nextSceneIndex = currentSlideIndex + 1;

        if (nextSceneIndex < Slides.Count)
        {
            currentSlideIndex = nextSceneIndex;

            SlideChanged?.Invoke(Slides[currentSlideIndex]);

            return Slides[currentSlideIndex];
        }

        return null;
    }

    public static Type GetPreviousSlideType()
    {
        var previousSceneIndex = currentSlideIndex - 1;

        if (previousSceneIndex >= 0)
        {
            currentSlideIndex = previousSceneIndex;

            SlideChanged?.Invoke(Slides[currentSlideIndex]);

            return Slides[currentSlideIndex];
        }

        return null;
    }
}

﻿using BuildingGames.Slides;
using Orbit.Engine;

namespace BuildingGames;

public partial class MainPage : ContentPage
{
    private readonly IGameSceneManager gameSceneManager;
    private readonly ControllerManager controllerManager;

    public MainPage(
        IGameSceneManager gameSceneManager,
        ControllerManager controllerManager)
	{
		InitializeComponent();

        this.gameSceneManager = gameSceneManager;
        this.controllerManager = controllerManager;

        LoadSlide(SlideDeck.CurrentSlideType);

#if MACCATALYST
        //this.controllerManager.Initialise();
        //this.controllerManager.ButtonPressed += ControllerManager_ButtonPressed;
#endif
    }

    private void ControllerManager_ButtonPressed(ControllerButton controllerButton)
    {
        ProgressSlides();
    }

    async void LoadSlide(Type sceneType)
    {
        if (GameView.Scene is SlideSceneBase previousScene)
        {
            previousScene.Back -= OnCurrentSceneBack;
            previousScene.Next -= OnCurrentSceneNext;
        }

        if (sceneType.IsAssignableTo(typeof(SlideSceneBase)))
        {
            this.gameSceneManager.LoadScene(sceneType, GameView);

            if (GameView.Scene is SlideSceneBase nextScene)
            {
                nextScene.Back += OnCurrentSceneBack;
                nextScene.Next += OnCurrentSceneNext;
            }

            this.gameSceneManager.Start();
        }
        else if (sceneType.IsAssignableTo(typeof(ContentPage)))
        {
            await Shell.Current.GoToAsync(sceneType.Name);
        }
    }

    private void OnCurrentSceneNext(SlideSceneBase sender)
    {
        if (SlideDeck.GetNextSlideType() is Type nextSlideType)
        {
            this.LoadSlide(nextSlideType);
        }
    }

    private void OnCurrentSceneBack(SlideSceneBase sender)
    {
        if (SlideDeck.GetPreviousSlideType() is Type previousSlideType)
        {
            this.LoadSlide(previousSlideType);
        }
    }

    void GameView_StartInteraction(object sender, TouchEventArgs e)
    {
        ProgressSlides();
    }

    void ProgressSlides()
    {
        if (GameView.Scene is SlideSceneBase slideSceneBase &&
            slideSceneBase.CanProgress)
        {
            slideSceneBase.Progress();
        }
    }
}

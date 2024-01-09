﻿using AirHockey.Scenes;
using Orbit.Engine;

namespace AirHockey;

public partial class MainPage : ContentPage
{
    private readonly IGameSceneManager gameSceneManager;
    private readonly MainScene mainScene;
    private PlayerStateManager playerStateManager;

	public MainPage(
        IGameSceneManager gameSceneManager,
        MainScene mainScene,
        PlayerStateManager playerStateManager)
	{
		InitializeComponent();

        this.playerStateManager = playerStateManager;
        this.gameSceneManager = gameSceneManager;
        this.mainScene = mainScene;
        //gameSceneManager.StateChanged += GameSceneManager_StateChanged;
        gameSceneManager.LoadScene<MainScene>(GameView);

        gameSceneManager.Start();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        try 
        {
            await playerStateManager.Connect();    
        }
        catch (Exception ex)
        {
            
        }

        playerStateManager.RegisterCallback(state => this.mainScene.UpdateOpponentPlayerState(state.X, state.Y));
    }

    void GameView_EndInteraction(object sender, TouchEventArgs e)
    {
        //TouchMode = TouchMode.None;
    }

    void GameView_StartInteraction(object sender, TouchEventArgs e)
    {
        
        //playerStateManager.UpdatePosition(e.)
        //var middle = GameView.Width / 2;

        //var touchX = e.Touches.First().X;

        //if (touchX >= middle)
        //{
        //    TouchMode = TouchMode.SpeedUp;
        //}
        //else
        //{
        //    TouchMode = TouchMode.SlowDown;
        //}
    }

    void GameView_DragInteraction(System.Object sender, Microsoft.Maui.Controls.TouchEventArgs e)
    {
        var touch = e.Touches.First();

        //Console.WriteLine($"{touch}");

        var bounds = GameView.Bounds;

        var relativeY = touch.Y / bounds.Height;
        var relativeX = touch.X / bounds.Width;

        _ = playerStateManager.UpdateState((int)relativeX, (int)relativeY);

        this.mainScene.UpdatePlayerState((int)touch.X, (int)touch.Y);
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GalacticWar;

public class StartScreenMenu
{
    private Texture2D backgroundStartScreen;
    private Button[] buttons;
    private int selectedButtonIndex;
    private KeyboardState prevKeyboardState;

    public StartScreenMenu(Texture2D background, Texture2D[] buttonTextures, Texture2D[] pressedButtonTextures, Vector2[] buttonPositions)
    {
        backgroundStartScreen = background;

        buttons = new Button[buttonTextures.Length];
        for (var i = 0; i < buttonTextures.Length; i++)
        {
            buttons[i] = new Button(buttonTextures[i], pressedButtonTextures[i], buttonPositions[i]);
        }
    }


    public void Update()
    {
        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.Up) && !prevKeyboardState.IsKeyDown(Keys.Up))
        {
            selectedButtonIndex--;
            if (selectedButtonIndex < 0)
                selectedButtonIndex = buttons.Length - 1;
        }
        else if (keyboard.IsKeyDown(Keys.Down) && !prevKeyboardState.IsKeyDown(Keys.Down))
        {
            selectedButtonIndex++;
            if (selectedButtonIndex >= buttons.Length)
                selectedButtonIndex = 0;
        }

        
        if (keyboard.IsKeyDown(Keys.Enter) && !prevKeyboardState.IsKeyDown(Keys.Enter))
        {
            
            if (selectedButtonIndex >= 0 && selectedButtonIndex < buttons.Length)
            {
                
                buttons[selectedButtonIndex].SetActive(true);

                // Выполняем действие в зависимости от индекса активной кнопки
                switch (selectedButtonIndex)
                {
                    case 0:
                        buttons[0].Update(keyboard);
                        // Нажата кнопка Play
                        break;
                    case 1:
                        buttons[1].Update(keyboard);
                        // Нажата кнопка Options
                        break;
                    case 2:
                        buttons[2].Update(keyboard);
                        // Нажата кнопка Exit
                        Environment.Exit(0);
                        break;
                }
            }
        }

        prevKeyboardState = keyboard;
    }


    public void Draw(SpriteBatch spriteBatch)
    {   
        spriteBatch.Draw(backgroundStartScreen, new Rectangle(-200, -5, 1024, 600), Color.White);

        foreach (var button in buttons)
            button.Draw(spriteBatch);
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GalacticWar;

public class Button
{
    private Texture2D defaultTexture;
    private Texture2D pressedTexture;
    private Vector2 position;
    private Rectangle rectangle;
    private bool isActive = false;

    public Button(Texture2D defaultTexture, Texture2D pressedTexture, Vector2 newPosition)
    {
        this.defaultTexture = defaultTexture;
        this.pressedTexture = pressedTexture;
        position = newPosition;
        rectangle = new Rectangle((int)position.X, (int)position.Y, defaultTexture.Width/4, defaultTexture.Height/4);
    }

    public void Update(KeyboardState keyboardState)
    {
        if (keyboardState.IsKeyDown(Keys.Enter))
            isActive = true;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        // Отрисовываем кнопку в зависимости от ее состояния
        var currentTexture = isActive ? pressedTexture : defaultTexture;
        spriteBatch.Draw(currentTexture, rectangle, Color.White);
        isActive = false;
    }


    public void SetActive(bool active)
    {
        isActive = active;
    }
}
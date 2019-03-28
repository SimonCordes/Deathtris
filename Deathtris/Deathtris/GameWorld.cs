using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Deathtris.Components;

namespace Deathtris
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D backgroundImage;
        private static ContentManager contentManager;
        private static List<GameObject> gameObjectsInWorld = new List<GameObject>();
        private static List<GameObject> gameObjectsToBeAdded = new List<GameObject>();
        private static List<GameObject> gameObjectsToBeRemoved = new List<GameObject>();

        
            


        GameObject player = new GameObject(new Vector2(1000,900));
        
        public static float deltaTime;
        /// <summary> 
        /// Gets the ContentManager.
        /// </summary>
        public static ContentManager ContentManager
        {
            get { return contentManager; }
        }

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            contentManager = Content;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player.AddComponent(new Player(1f, 30f));
            player.AddComponent(new AnimatedSpriteRenderer(player, "spritesheet", 26, 5, 26));
            gameObjectsInWorld.Add(player);
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundImage = Content.Load<Texture2D>("SpriteBagground");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            UpdateListOfGameObjects();
            foreach (GameObject gameObject in gameObjectsInWorld)
            {
                gameObject.Update(gameTime);
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.TransparentBlack);
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundImage, new Vector2(0, 0), null, null, null, 0, null, Color.White, SpriteEffects.None, 0.5f);

            foreach (GameObject gameObject in gameObjectsInWorld)
            {       
                gameObject.Draw(spriteBatch);
            }

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }


        #region GameObject Handling

        /// <summary>
        /// Handles the update logic for the lists in the GameWorld.
        /// </summary>
        private void UpdateListOfGameObjects()
        {
            foreach (GameObject gameObject in gameObjectsToBeRemoved)
            {
                gameObjectsInWorld.Remove(gameObject);
            }
            gameObjectsToBeRemoved.Clear();
            foreach (GameObject gameObject in gameObjectsToBeAdded)
            {
                gameObjectsInWorld.Add(gameObject);
            }
            gameObjectsToBeAdded.Clear();

        }

        /// <summary>
        /// Adds a GameObject to the world. 
        /// </summary>
        /// <param name="gameObject"></param>
        public static void AddGameObject(GameObject gameObject)
        {
            try
            {
                gameObject.LoadContent(contentManager);
                gameObjectsToBeAdded.Add(gameObject);
            }
            catch (Exception e)
            {

                Debug.Print(e.Message);
            }
        }
        

        /// <summary>
        /// Removes the object from the GameWorld.
        /// </summary>
        /// <param name="gameObject"></param>
        public static void RemoveGameObject(GameObject gameObject)
        {
            gameObjectsToBeRemoved.Remove(gameObject);
        }



        #endregion

    }
}

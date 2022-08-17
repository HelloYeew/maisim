using System;
using maisim.Game.Screen.Gameplay;
using maisim.Game.Utils;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osuTK;

namespace maisim.Game.Component.Gameplay.Notes
{
    /// <summary>
    /// A base abstract class for notes in the gameplay.
    /// </summary>
    public abstract class DrawableNote : CompositeDrawable
    {
        public readonly double FADE_IN_TIME = 75f;

        public NoteLane Lane { get; set; }

        protected readonly Bindable<NoteActivationState> State = new Bindable<NoteActivationState>();

        [BackgroundDependencyLoader]
        private void load(TextureStore textureStore)
        {
            InternalChild = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(50),
                Children = AddNoteParts(textureStore)
            };

            // hide the note by default
            Hide();

            //required to handle state updates when hidden.
            AlwaysPresent = true;

            State.BindValueChanged(UpdateActivationState);
        }

        /// <summary>
        /// The time that the note need to be hit in milliseconds.
        /// </summary>
        public double TargetTime;

        /// <summary>
        /// Add the note sprite parts to the main class container.
        /// </summary>
        /// <param name="textureStore"><see cref="TextureStore"/> in load operation.</param>
        /// <returns>List of drawable include all note part that will be initialize on load.</returns>
        protected abstract Drawable[] AddNoteParts(TextureStore textureStore);

        /// <summary>
        /// Check that the note can start to despawn state.
        /// </summary>
        /// <returns>True if the note can start despawn state.</returns>
        public abstract bool CanDespawn { get; }

        protected override void Update()
        {
            base.Update();

            // Start spawning animation but not update its position.
            if (Clock.TimeInfo.Current >= TargetTime - Playfield.TIME_NOTE_APPEARS - FADE_IN_TIME && State.Value == NoteActivationState.Inactive)
                State.Value = NoteActivationState.Spawning;

            // note active state should become Active when the clock time reaches near the target time
            if (Clock.TimeInfo.Current >= TargetTime - Playfield.TIME_NOTE_APPEARS && State.Value == NoteActivationState.Spawning)
                State.Value = NoteActivationState.Active;

            if (State.Value == NoteActivationState.Active)
                UpdatePosition();

            if (CanDespawn)
                State.Value = NoteActivationState.Inactive;
        }

        /// <summary>
        /// Update the activation state of this <see cref="DrawableNote"/>
        /// </summary>
        /// <param name="e"></param>
        protected virtual void UpdateActivationState(ValueChangedEvent<NoteActivationState> e)
        {
            switch (e.NewValue)
            {
                case NoteActivationState.Spawning:
                    this.FadeIn(FADE_IN_TIME, Easing.InBounce);
                    break;

                case NoteActivationState.Inactive:
                case NoteActivationState.Judged:
                    this.FadeOut(50, Easing.OutBounce);
                    Expire();
                    break;
            }
        }

        /// <summary>
        /// Update the note position based on the elapsed time.
        /// </summary>
        protected virtual void UpdatePosition()
        {
            double speed = MathUtils.EuclideanDistance(
                NoteLaneExtension.GetSpawnerPosition(Lane),
                NoteLaneExtension.GetSensorPosition(Lane)) / Playfield.TIME_NOTE_APPEARS;


            Position = new Vector2(
                (float)(Position.X +
                        ((float)(speed *
                                 (-(float)Math.Cos(
                                     (NoteLaneExtension.GetAngle(Lane) + 90f) * (float)(Math.PI / 180)))) *
                         Clock.ElapsedFrameTime)),
                (float)(Position.Y +
                        ((float)(speed *
                                 (-(float)Math.Sin(
                                     (NoteLaneExtension.GetAngle(Lane) + 90f) * (float)(Math.PI / 180)))) *
                         Clock.ElapsedFrameTime))
            );
        }
    }

    /// <summary>
    /// Represent the state
    /// </summary>
    public enum NoteActivationState
    {
        Inactive, // Not active yet / not active anymore
        Spawning,
        Active,
        Judged, // Judged, not active anymore
    }
}

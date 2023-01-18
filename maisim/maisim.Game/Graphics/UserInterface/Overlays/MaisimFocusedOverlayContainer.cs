using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Sample;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Events;

namespace maisim.Game.Graphics.UserInterface.Overlays
{
    public partial class MaisimFocusedOverlayContainer : FocusedOverlayContainer
    {
        private Sample popInSample;
        private Sample popOutSample;
        protected virtual string PopInSampleName => "pop-in";
        protected virtual string PopOutSampleName => "pop-out";

        protected override bool BlockScrollInput => false;
        protected override bool BlockNonPositionalInput => false;

        [BackgroundDependencyLoader(true)]
        private void load(AudioManager audioManager)
        {
            popInSample = audioManager.Samples.Get(PopInSampleName);
            popOutSample = audioManager.Samples.Get(PopOutSampleName);
        }

        private bool closeOnMouseUp;

        protected override void UpdateState(ValueChangedEvent<Visibility> state)
        {
            bool didChange = state.NewValue != state.OldValue;

            switch (state.NewValue)
            {
                case Visibility.Visible:
                    if (didChange)
                        popInSample?.Play();

                    break;

                case Visibility.Hidden:
                    if (didChange)
                        popOutSample?.Play();

                    break;
            }

            base.UpdateState(state);
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            closeOnMouseUp = !base.ReceivePositionalInputAt(e.ScreenSpaceMousePosition);

            return base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseUpEvent e)
        {
            if (closeOnMouseUp && !base.ReceivePositionalInputAt(e.ScreenSpaceMousePosition))
                Hide();

            base.OnMouseUp(e);
        }
    }
}

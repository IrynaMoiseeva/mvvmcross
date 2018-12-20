using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Android.Views;
using Com.Airbnb.Lottie;
using System.Windows.Input;
using Android.Animation;

namespace MvvmCross_Application1.Droid.Controls
{

    [Register("LottieFavoriteButton")]
    public class LottieFavoriteButton : FrameLayout
    {
        public const float AnimationProgressEndFrame = 0.8f;
        public const float AnimationProgressStartFrame = 0.0f;
        private ValueAnimator animator;

        private class FavoriteButtonAnimationListener : AnimatorListenerAdapter, ValueAnimator.IAnimatorUpdateListener
        {
            private readonly Action<Animator> onAnimationEnd;
            private readonly LottieAnimationView lottieAnimationView;

            public FavoriteButtonAnimationListener(Action<Animator> onAnimationEnd, LottieAnimationView lottieAnimationView)
            {
                this.onAnimationEnd = onAnimationEnd;
                this.lottieAnimationView = lottieAnimationView;
            }

            public override void OnAnimationEnd(Animator animation)
            {
              
                    lottieAnimationView.RemoveAnimatorListener(this);
                    onAnimationEnd(animation);
            }

            public void OnAnimationUpdate(ValueAnimator animation)
            {
                throw new NotImplementedException();
            }
        }

        public const int DefStyleAttr = 0;
        public const int DefStyleRes = 0;

       // private TextView label;
        private LottieAnimationView animationView;
        private float animationProgressForCallBack;

        public LottieFavoriteButton(IntPtr ptr, JniHandleOwnership owner)
            : base(ptr, owner)
        {
        }

        public LottieFavoriteButton(Context context, IAttributeSet attrs)
            : this(context, attrs, DefStyleAttr)
        {
        }

         public LottieFavoriteButton(Context context, IAttributeSet attrs, int defStyleAttr)
             : this(context, attrs, defStyleAttr, DefStyleRes)
         {
         }
 
         public LottieFavoriteButton(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
             : base(context, attrs, defStyleAttr, defStyleRes)
         {
             Init(context, attrs, defStyleAttr, defStyleRes);
         }

        public LottieAnimationView AnimationView => animationView;

        public ICommand OnClickCommandLike{ get; set; }
        public ICommand OnClickCommandDisLike { get; set; }
        public bool IsLike { get; set; }


        public float LazyAnimationProgress
        {
            get { return animationView.Progress; }
            set
            {
                animationView.Progress = value;

            }
        }

        protected void Init(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
        {
            var view = LayoutInflater.From(context).Inflate(Resource.Layout.LottieFavoriteButton, root: this, attachToRoot: false);
             AddView(view, new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));

            animationView = view.FindViewById<LottieAnimationView>(Resource.Id.lottie_favorite_button_image);
            animationView.SetAnimation("favorite_black.json");
            animationView.Progress = AnimationProgressStartFrame;


            FindViewById(Resource.Id.lottie_favorite_button).Click += delegate
              {
                  
                animator = ValueAnimator.OfFloat(AnimationProgressStartFrame, AnimationProgressEndFrame);
                  animator.SetDuration(500);
                  animator.AddUpdateListener(new OnAnimationClickListener(animationView));
                  if (animationView.Progress == AnimationProgressStartFrame)
                  {
                      animator.Start();
                      OnClickCommandLike.Execute(null);
                  }
                  else
                  {
                      animationView.Progress = AnimationProgressStartFrame;
                      OnClickCommandDisLike.Execute(null);
                  }
              };
        }

        public class OnAnimationClickListener : Java.Lang.Object, ValueAnimator.IAnimatorUpdateListener
        {
            private LottieAnimationView animationView;
            public OnAnimationClickListener(LottieAnimationView animationView)
            {
                this.animationView = animationView;
            }

           
            public void OnAnimationUpdate(ValueAnimator animator)
            {
                animationView.Progress = (float)animator.AnimatedValue;

            }
        }
        private void OnAnimationCompleted(Animator animator)
        {
           
            if (animationView.Progress >= 0.0f)
                animationView.Progress = 0.8f;
                   
                else
                {
                animationView.Progress = 0.0f;

                }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                OnClickCommandLike = null;
            }

            base.Dispose(disposing);
        }
    }
}


export enum TransitionState { None, FadeIn, FadeOut }

export const transitionClass = (state: TransitionState) => {
    switch (state) {
        case TransitionState.None:
            return '';
        case TransitionState.FadeIn:
            return 'fade-in'
        case TransitionState.FadeOut:
            return 'fade-out'
    }
}

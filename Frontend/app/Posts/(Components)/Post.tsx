import React from 'react'

const Post = () => {
  return (
    <>
    <article
                className="bg-surface-container-lowest rounded-lg overflow-hidden shadow-[0_20px_40px_rgba(27,27,31,0.06)] transition-all">
                {/* <!-- Header --> */}
                <div className="p-6 flex items-center justify-between">
                    <div className="flex items-center gap-4">
                        <div className="w-12 h-12 rounded-full overflow-hidden">
                            <img data-alt="Close-up of a woman smiling outdoors in a sunlit field, high-end lifestyle photography"
                                src="https://lh3.googleusercontent.com/aida-public/AB6AXuBRAVJSLeON-hBfcTI3Gu_KXKdNUey9GYdSqFmdCdGeZoSAS4dr1Q0JJIyNj-aH6rD8IHKbU6PA-gaOzoSQASInmOagzyshuduNCxmmM3jLQbhWT4uMcoExCYvlKcKhO4ZFIUtwyCXNhuB2rlTSYypK9SgMeNzOB7DnnqZczmT8Ht8ym1Y3_qWhLWAgfXo2AgLaBcJ_N1lEy4zqdbXuJwJdTJbXf1ntCWgpSfX_8efksXBZcpz7sLX2Rsp6ZL6eHJNoJhGh4Xwsk68" />
                        </div>
                        <div>
                            <h3 className="font-headline font-bold text-primary">Elena Rodriguez</h3>
                            <p className="text-xs text-on-surface-variant">Editorial Contributor • 2h ago</p>
                        </div>
                    </div>
                    <button className="text-on-surface-variant hover:text-primary"><span className="material-symbols-outlined"
                            data-icon="more_horiz">more_horiz</span></button>
                </div>
                {/* <!-- Content --> */}
                <div className="px-6 pb-4">
                    <h4 className="font-headline font-extrabold text-2xl text-primary mb-2">Sun-Drenched Afternoons in
                        Provence</h4>
                    <p className="text-on-surface-variant leading-relaxed">
                        There's a specific kind of magic when the golden hour hits the lavender fields and Beau decides
                        it's the perfect time for a contemplative stroll. Capturing the quiet dignity of a rescue who
                        finally found his sanctuary.
                    </p>
                </div>
                {/* <!-- Media Carousel --> */}
                <div className="relative group">
                    <div className="flex overflow-x-auto no-scrollbar snap-x snap-mandatory">
                        <div className="flex-shrink-0 w-full aspect-[4/5] snap-center">
                            <img className="w-full h-full object-cover"
                                data-alt="Majestic golden retriever sitting elegantly in a field of purple lavender at sunset, warm cinematic lighting"
                                src="https://lh3.googleusercontent.com/aida-public/AB6AXuBknleqcM9P3YIRA_zjdJP4otMcFhsqNqzKOiJ7rI0TuCWKlGV9CGRVFeDPUIxNgRTRilNNYvUxhwkiW2OA7Gry7CrTFt_8pavT6vjEbjZgjH2l6VifVvjOyFyRum9O1R2K49n06deJJo-_x45pEKJ9j8v_07iPYJLjRjnzbzoZQlgy4kTBHKGAAgJRsOp7TC1-uAPCF9uMfEZp4X-_Z74MSTbmx86gVK3h3KhfRei_V3pMIOqHunIzg2NybnQIVmott8mBGYkpGfA" />
                        </div>
                        <div className="flex-shrink-0 w-full aspect-[4/5] snap-center">
                            <img className="w-full h-full object-cover"
                                data-alt="Close up of a dog's paws walking through dry grass, soft afternoon sunlight, artistic focus"
                                src="https://lh3.googleusercontent.com/aida-public/AB6AXuDJ8AnxSTy10FztKRwGs1fQUse0egmRyZRIpRb2YOWO4T98dUeSUIWs8PTZn9mMeVcBL-17u378rM1OLA1VM-K6-p1kJ7mJhOQS8cHd3p-PXe8J5ocy4kkefW4ighGLE4WbvFl8M0_1iv5SVFD4E8C8hht18FkzMX85Iiq4PpxokZZeBoyCk9RjZ-IGF7qJ21_NW-Io0it9P1nredw3G2Qtt8bzz5KHitXK7wxz_6H9-hPJ9ap7ZXuIVCasM9EKPxfuG1yB4rR_hhA" />
                        </div>
                        <div className="flex-shrink-0 w-full aspect-[4/5] snap-center">
                            <img className="w-full h-full object-cover"
                                data-alt="Portrait of a happy dog looking into the camera lens with tongue out, outdoors, bright natural lighting"
                                src="https://lh3.googleusercontent.com/aida-public/AB6AXuAxn53rbS8-IoJYh1kuwOe8zfLFfGBrgLlT4Puth4TyOwn7Waf6ZehZwpGuB2eUAUF_kmaiyQUsZsrNydPJPbHbNS4232IOwhXBOqy6KQNDevKGaOlYWhbHS_XGYWnl7Ap2sJgAV3oRkON5CE_BGz6aB8nh59hizFHzXXt1gD9CHE-tGCuDZl2pbC7OIyJddWyFkieSJwHnOCBeYWk0dO07PldW8hVWzOBnemXLxPfA7ux1pZ_QGRac4cb8xqLQL1CiWzp3AarM-rE" />
                        </div>
                    </div>
                    {/* <!-- Pet Details Overlay --> */}
                    <div className="absolute bottom-6 left-6 right-6">
                        <div
                            className="bg-surface/80 backdrop-blur-xl p-5 rounded-lg border-outline-variant/10 shadow-xl flex items-center justify-between">
                            <div>
                                <span
                                    className="text-[10px] font-black uppercase tracking-[0.2em] text-on-secondary-fixed-variant mb-1 block">Featured
                                    Companion</span>
                                <h5 className="font-headline font-extrabold text-xl text-primary">Beau</h5>
                                <p className="text-sm text-on-surface-variant">Golden Retriever • 4 Years • Provence, FR</p>
                            </div>
                            <div
                                className="bg-secondary-fixed px-4 py-2 rounded-full text-on-secondary-fixed text-xs font-bold">
                                Adopted
                            </div>
                        </div>
                    </div>
                    {/* <!-- Carousel Indicators --> */}
                    <div className="absolute top-6 right-6 flex gap-1.5">
                        <div className="w-1.5 h-1.5 bg-white rounded-full"></div>
                        <div className="w-1.5 h-1.5 bg-white/40 rounded-full"></div>
                        <div className="w-1.5 h-1.5 bg-white/40 rounded-full"></div>
                    </div>
                </div>
                {/* <!-- Footer --> */}
                <div className="p-6 flex items-center justify-between border-t border-surface-container/50">
                    <div className="flex items-center gap-6">
                        <button className="flex items-center gap-2 group transition-all">
                            <span
                                className="material-symbols-outlined text-on-surface-variant group-hover:text-error transition-colors"
                                data-icon="favorite">favorite</span>
                            <span className="text-sm font-bold text-on-surface-variant group-hover:text-primary">1.2k</span>
                        </button>
                        <button className="flex items-center gap-2 group transition-all">
                            <span
                                className="material-symbols-outlined text-on-surface-variant group-hover:text-primary transition-colors"
                                data-icon="chat_bubble">chat_bubble</span>
                            <span className="text-sm font-bold text-on-surface-variant group-hover:text-primary">48</span>
                        </button>
                        <button className="flex items-center gap-2 group transition-all">
                            <span
                                className="material-symbols-outlined text-on-surface-variant group-hover:text-primary transition-colors"
                                data-icon="share">share</span>
                        </button>
                    </div>
                    <button className="text-primary hover:scale-110 transition-transform">
                        <span className="material-symbols-outlined" data-icon="bookmark">bookmark</span>
                    </button>
                </div>
            </article>
    </>
  )
}

export default Post
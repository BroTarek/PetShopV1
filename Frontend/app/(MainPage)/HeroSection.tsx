import React from 'react'

const HeroSection = () => {
  return (<section
            className="relative px-6 md:px-12 py-20 max-w-screen-2xl mx-auto flex flex-col md:flex-row items-center gap-16">
            <div className="w-full md:w-1/2 z-10">
                <span
                    className="inline-block px-4 py-1.5 mb-6 rounded-full bg-secondary-fixed text-on-secondary-fixed text-xs font-bold uppercase tracking-widest">Premium
                    Care</span>
                <h1 className="text-6xl md:text-8xl font-extrabold tracking-tighter leading-[0.9] text-primary mb-8">
                    Elevated living <br />for your best <br />friend.
                </h1>
                <p className="text-xl text-on-surface-variant max-w-md mb-10 leading-relaxed">
                    Moving beyond the pet store. Discover a curated collection of artisanal essentials and companionship
                    designed for the modern home.
                </p>
                <div className="flex flex-wrap gap-4">
                    <button
                        className="px-10 py-5 bg-primary text-on-primary rounded-xl font-bold transition-all satin-hover flex items-center gap-2">
                        Find Your New Friend
                        <span className="material-symbols-outlined text-sm" data-icon="arrow_forward">arrow_forward</span>
                    </button>
                    <button
                        className="px-10 py-5 bg-surface-container-high text-on-surface rounded-xl font-bold hover:bg-surface-container-highest transition-colors">
                        Explore Shop
                    </button>
                </div>
            </div>
            <div className="w-full md:w-1/2 relative">
                <div className="absolute -top-12 -left-12 w-64 h-64 bg-secondary-container/30 rounded-full blur-3xl -z-10">
                </div>
                <div
                    className="rounded-lg overflow-hidden transform rotate-2 hover:rotate-0 transition-transform duration-700 shadow-2xl shadow-on-surface/10">
                    <img alt="Elegant Golden Retriever" className="w-full h-[600px] object-cover"
                        data-alt="Close-up portrait of a happy Golden Retriever in a sunlit modern apartment with soft focus greenery and warm natural lighting"
                        src="https://lh3.googleusercontent.com/aida-public/AB6AXuAbZJkxzogqdis_9w6NMamMq5-0TMYB2q3H5VybGNeWPfdr3SgCYgHi7pYXE1CbvlT2qwdTIMA_cBQ1QwSiMl2uEF3wTJqECMksr6nVQNvfZM8Am-67xifVn9Pa-OOa93nhg5MOghQVY_AmEGBzta-PaBjYp3-zp3KLHS1eCu800xXKET-NmtqE0YfmF0RN9Chw-Pw2zSgHgwtuR6rL5z1fA0qDo-viAtNfhBj2X3SZY9rxDCd4coxgoNEtNOSgzs383hxzniYQU2s" />
                </div>
                <div
                    className="absolute -bottom-6 -right-6 md:-right-12 p-8 bg-surface-container-lowest rounded-lg shadow-xl max-w-xs transform -rotate-2">
                    <div className="flex items-center gap-4 mb-4">
                        <div className="w-12 h-12 rounded-full bg-secondary-fixed flex items-center justify-center">
                            <span className="material-symbols-outlined text-on-secondary-fixed" data-icon="pets">pets</span>
                        </div>
                        <div>
                            <p className="text-sm font-bold">Today's Highlight</p>
                            <p className="text-xs text-on-surface-variant">Artisanal Cedar Beds</p>
                        </div>
                    </div>
                    <p className="text-xs italic text-on-surface-variant">"The only bed my Luna actually stays in all night
                        long." - Sarah J.</p>
                </div>
            </div>
        </section>
  )
}

export default HeroSection
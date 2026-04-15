import React from 'react'

const ProfileSummary = () => {
  return (
      <div className="md:col-span-5 lg:col-span-4 flex flex-col gap-6">
                <div className="bg-surface-container-low rounded-lg p-8 md:p-10 flex-grow flex flex-col justify-between">
                    <div>
                        <div className="flex items-center gap-3 mb-4">
                            <span
                                className="bg-secondary-fixed text-on-secondary-fixed text-xs font-bold px-4 py-1.5 rounded-full font-headline uppercase tracking-widest">Available</span>
                            <span className="text-on-surface-variant text-sm font-medium">Ref: CC-8802</span>
                        </div>
                        <h1
                            className="text-6xl font-extrabold tracking-tighter text-primary mb-4 font-headline leading-[0.9]">
                            Beau.</h1>
                        <p className="text-on-surface-variant text-lg leading-relaxed font-light mb-8">
                            A gentleman by nature and a comedian by choice. Beau is looking for a sun-drenched living
                            room and a human who appreciates the finer points of nap-taking.
                        </p>
                    </div>
                    <div className="flex flex-col gap-4">
                        <button
                            className="bg-primary text-on-primary rounded-xl py-5 px-8 flex items-center justify-center gap-3 satin-hover transition-all duration-300 font-bold group">
                            <span className="font-headline tracking-tight">Begin Adoption Journey</span>
                            <span className="material-symbols-outlined group-hover:translate-x-1 transition-transform"
                                data-icon="arrow_forward">arrow_forward</span>
                        </button>
                        <button
                            className="bg-surface-container-lowest text-primary rounded-xl py-5 px-8 border border-outline-variant/20 font-bold hover:bg-surface-container-high transition-colors font-headline tracking-tight">
                            Schedule a Visit
                        </button>
                    </div>
                </div>
                {/* <!-- Adoption Stats --> */}
                <div className="grid grid-cols-2 gap-4">
                    <div
                        className="bg-surface-container-lowest rounded-lg p-6 border border-outline-variant/10 text-center">
                        <span className="block text-2xl font-black text-primary font-headline">2 Years</span>
                        <span className="text-xs text-on-surface-variant font-medium uppercase tracking-widest">Age</span>
                    </div>
                    <div
                        className="bg-surface-container-lowest rounded-lg p-6 border border-outline-variant/10 text-center">
                        <span className="block text-2xl font-black text-primary font-headline">22 lbs</span>
                        <span
                            className="text-xs text-on-surface-variant font-medium uppercase tracking-widest">Weight</span>
                    </div>
                </div>
            </div>
  )
}

export default ProfileSummary
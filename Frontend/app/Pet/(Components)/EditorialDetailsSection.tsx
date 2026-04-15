import React from 'react'

const EditorialDetailsSection = () => {
  return (
    <>
     <div className="grid grid-cols-1 md:grid-cols-12 gap-12 lg:gap-24 mb-32 items-start">
            <div className="md:col-span-4 sticky top-32">
                <h2 className="text-4xl font-extrabold tracking-tighter text-primary mb-6 font-headline">The Dossier
                </h2>
                <p className="text-on-surface-variant leading-relaxed">Everything you need to know about Beau's personality,
                    quirks, and medical background curated by our behaviorists.</p>
                <div className="mt-12 flex flex-col gap-6">
                    <div className="flex items-center gap-4">
                        <span
                            className="material-symbols-outlined text-secondary-container bg-secondary w-12 h-12 flex items-center justify-center rounded-full"
                            data-icon="verified_user" style={{fontVariationSettings: "'FILL' 1"}}>verified_user</span>
                        <div>
                            <p className="font-bold text-sm">Health Certified</p>
                            <p className="text-xs text-on-surface-variant">Full vetting completed Sept 2023</p>
                        </div>
                    </div>
                    <div className="flex items-center gap-4">
                        <span
                            className="material-symbols-outlined text-secondary-container bg-secondary w-12 h-12 flex items-center justify-center rounded-full"
                            data-icon="home_health" style={{fontVariationSettings: "'FILL' 1"}}>home_health</span>
                        <div>
                            <p className="font-bold text-sm">Foster Graduate</p>
                            <p className="text-xs text-on-surface-variant">Socialized in a multi-pet home</p>
                        </div>
                    </div>
                </div>
            </div>
            <div className="md:col-span-8 grid grid-cols-1 md:grid-cols-2 gap-8">
                {/* <!-- Detail Card 1: Temperament --> */}
                <div className="bg-surface-container-lowest rounded-lg p-8 editorial-shadow">
                    <h3 className="text-xl font-bold mb-4 font-headline flex items-center gap-2">
                        <span className="material-symbols-outlined text-secondary" data-icon="mood">mood</span>
                        Temperament
                    </h3>
                    <ul className="space-y-4">
                        <li className="flex items-start gap-3">
                            <span className="w-1.5 h-1.5 rounded-full bg-secondary mt-2"></span>
                            <span className="text-on-surface-variant text-sm">Extremely social with humans; thinks everyone
                                is a friend.</span>
                        </li>
                        <li className="flex items-start gap-3">
                            <span className="w-1.5 h-1.5 rounded-full bg-secondary mt-2"></span>
                            <span className="text-on-surface-variant text-sm">Low energy profile; prefers short walks and
                                long naps.</span>
                        </li>
                        <li className="flex items-start gap-3">
                            <span className="w-1.5 h-1.5 rounded-full bg-secondary mt-2"></span>
                            <span className="text-on-surface-variant text-sm">Intelligent but stubborn; responds best to
                                high-value treats.</span>
                        </li>
                    </ul>
                </div>
                {/* <!-- Detail Card 2: Medical --> */}
                <div className="bg-surface-container-lowest rounded-lg p-8 editorial-shadow">
                    <h3 className="text-xl font-bold mb-4 font-headline flex items-center gap-2">
                        <span className="material-symbols-outlined text-secondary"
                            data-icon="medical_services">medical_services</span>
                        Medical History
                    </h3>
                    <ul className="space-y-4">
                        <li className="flex items-center justify-between border-b border-outline-variant/10 pb-3">
                            <span className="text-sm font-medium">Vaccinations</span>
                            <span
                                className="bg-secondary-fixed text-on-secondary-fixed text-[10px] px-3 py-1 rounded-full font-bold uppercase tracking-tighter">Current</span>
                        </li>
                        <li className="flex items-center justify-between border-b border-outline-variant/10 pb-3">
                            <span className="text-sm font-medium">Neutered</span>
                            <span
                                className="bg-secondary-fixed text-on-secondary-fixed text-[10px] px-3 py-1 rounded-full font-bold uppercase tracking-tighter">Yes</span>
                        </li>
                        <li className="flex items-center justify-between pb-3">
                            <span className="text-sm font-medium">Special Diet</span>
                            <span className="text-on-surface-variant text-xs italic">Grain-free sensitive</span>
                        </li>
                    </ul>
                </div>
                {/* <!-- Large Bio Block --> */}
                <div className="md:col-span-2 bg-secondary-container rounded-lg p-10 relative overflow-hidden">
                    <div className="relative z-10">
                        <h3 className="text-2xl font-extrabold mb-6 font-headline text-on-secondary-container">The
                            Lifestyle Fit</h3>
                        <p className="text-on-secondary-container/80 leading-relaxed text-lg italic">
                            "Beau is the perfect companion for an apartment dweller or someone who works from home. He
                            isn't much of a barker, but he is a world-className snorer. He enjoys the aesthetic of a clean
                            home and will happily model his latest harness collection for your Instagram followers."
                        </p>
                    </div>
                    <span
                        className="absolute -bottom-10 -right-10 material-symbols-outlined text-on-secondary-container/10 text-[200px]"
                        data-icon="pets">pets</span>
                </div>
            </div>
        </div>
    </>
  )
}

export default EditorialDetailsSection
import React from 'react'

const ActivitiesSection = () => {
  return (
    <>
    
        <div className="max-w-2xl mx-auto">
            {/* <!-- Section Header --> */}
            <div className="mb-10 text-center md:text-left">
                <h1 className="text-4xl md:text-5xl font-extrabold font-headline tracking-tight text-primary mb-4">All
                    Activities</h1>
                <p className="text-on-surface-variant max-w-md">Keep track of your interactions, pet updates, and community
                    conversations in one place.</p>
            </div>
            {/* <!-- Pill Navigation Tabs --> */}
            <div className="sticky top-[88px] z-40 bg-background/50 backdrop-blur-sm py-4 -mx-4 px-4 mb-8">
                <div className="flex bg-surface-container-low p-1.5 rounded-full w-full">
                    <button
                        className="flex-1 py-3 px-6 rounded-full text-sm font-bold transition-all duration-300 bg-primary text-on-primary shadow-editorial-shadow font-headline">
                        Posts
                    </button>
                    <button
                        className="flex-1 py-3 px-6 rounded-full text-sm font-medium text-on-surface-variant hover:bg-surface-container-high transition-all font-headline">
                        Comments
                    </button>
                    <button
                        className="flex-1 py-3 px-6 rounded-full text-sm font-medium text-on-surface-variant hover:bg-surface-container-high transition-all font-headline">
                        Pets
                    </button>
                </div>
            </div>
            {/* <!-- Scrollable Feed --> */}
            <div className="space-y-12">
                {/* <!-- Activity Item 1: Media Post --> */}
                <article className="group">
                    <div className="flex items-center justify-between mb-4">
                        <div className="flex items-center gap-3">
                            <div className="w-12 h-12 rounded-full overflow-hidden">
                                <img alt="Elena Rodriguez"
                                    data-alt="close-up portrait of a woman with curly hair smiling in a park with warm dappled sunlight"
                                    src="https://lh3.googleusercontent.com/aida-public/AB6AXuAjgv-WWUWpfCoOpjo6Bx1-B04J_-rxeRkHLEnTNFDkvp6quDDsZzN7IaPdFjgZbViSAZNzD8LPGHS6s3dRII0LPKDFMdAaRWz-ZwcfF08zoGX-9mnb1JZrAC63h2jN6AMDt0wSgHgSiiCSZd804so5_DoUlsWr6_IvCjJ8lqxu0JhA-hY5UoqK4zWpGWbD9O7H-OQZJtQuCuDgGV_YF3_ICLcg65cXnYyYlWPi1xE2642tA7wlwTojVY2iNN9ElJSLvKxjzNdDFBg" />
                            </div>
                            <div>
                                <h3 className="font-bold text-primary font-headline">Elena Rodriguez</h3>
                                <p className="text-xs text-on-surface-variant">2 hours ago • <span
                                        className="text-secondary font-semibold font-headline">Goldie's Mom</span></p>
                            </div>
                        </div>
                        <button className="p-2 text-on-surface-variant hover:text-primary" data-icon="more_horiz">
                            <span className="material-symbols-outlined">more_horiz</span>
                        </button>
                    </div>
                    <div
                        className="bg-surface-container-lowest rounded-lg overflow-hidden shadow-editorial-shadow transition-all duration-300 group-hover:shadow-editorial-hover group-hover:-translate-y-1">
                        <div className="aspect-[4/5] relative">
                            <img alt="Golden Retriever puppy" className="w-full h-full object-cover"
                                data-alt="golden retriever puppy sitting in a meadow of yellow wildflowers during sunset golden hour"
                                src="https://lh3.googleusercontent.com/aida-public/AB6AXuBuNv2Kmvb92qwtYsQFpdj8cN7srLYVVltAiNc0rcNxx9hIy5lYWtmvfzlnmjmM0wkcIy6HSIbakKlC9FcmjqogWG_tbUdn9oZzDE0zLdM4KAaDxG_f1o84p6aIJy63Ba6Ltr02dKqlpPHkG3-JKUlNGZg7WgQ-04gS-s11X5qXmXfw8L5NN5qdIJungBy9DEUML7eW8QkBaPInVwbf99_YhfUPbKzTnVv2QpKA06ASC2wVMDbm1zAauy91V7tkRM7Q_8jS4BE8PEg" />
                            <div
                                className="absolute top-4 right-4 bg-surface/20 backdrop-blur-md rounded-full px-3 py-1 text-[10px] font-bold text-on-surface uppercase tracking-widest font-headline">
                                New Member
                            </div>
                        </div>
                        <div className="p-6">
                            <p className="text-on-surface leading-relaxed mb-6 font-medium italic">
                                "Just brought Goldie home today! She's already found her favorite spot in the sun.
                                Anyone have tips for first-time Golden owners?"
                            </p>
                            <div className="flex items-center justify-between pt-6 border-t border-surface-container">
                                <div className="flex gap-6">
                                    <button className="flex items-center gap-2 group/action" data-icon="favorite">
                                        <span
                                            className="material-symbols-outlined text-on-surface-variant group-hover/action:text-error transition-colors">favorite</span>
                                        <span className="text-sm font-semibold text-on-surface-variant">124</span>
                                    </button>
                                    <button className="flex items-center gap-2 group/action" data-icon="chat_bubble">
                                        <span
                                            className="material-symbols-outlined text-on-surface-variant group-hover/action:text-primary transition-colors">chat_bubble</span>
                                        <span className="text-sm font-semibold text-on-surface-variant">18</span>
                                    </button>
                                </div>
                                <button className="flex items-center gap-2 group/action" data-icon="share">
                                    <span
                                        className="material-symbols-outlined text-on-surface-variant group-hover/action:text-primary transition-colors">share</span>
                                </button>
                            </div>
                        </div>
                    </div>
                </article>
            </div>
        </div>
        
    </>
  )
}

export default ActivitiesSection
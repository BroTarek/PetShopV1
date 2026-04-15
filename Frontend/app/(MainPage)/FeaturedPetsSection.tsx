import React from 'react'

const FeaturedPetsSection = () => {
  return (
     <section className="bg-surface-container-low rounded-t-lg px-6 md:px-12 py-32">
            <div className="max-w-screen-2xl mx-auto">
                <div className="flex flex-col md:flex-row md:items-end justify-between mb-20 gap-8">
                    <div className="max-w-2xl">
                        <h2 className="text-4xl md:text-5xl font-extrabold tracking-tight text-primary mb-6">Meet the
                            Companions</h2>
                        <p className="text-lg text-on-surface-variant">Every pet has a story. We help you find the one that
                            perfectly aligns with your lifestyle and home.</p>
                    </div>
                    <button
                        className="flex items-center gap-2 font-bold text-primary border-b-2 border-secondary-fixed hover:bg-secondary-fixed/20 px-4 py-2 transition-all">
                        View All Pets <span className="material-symbols-outlined"
                            data-icon="keyboard_arrow_right">keyboard_arrow_right</span>
                    </button>
                </div>
                <div className="grid grid-cols-1 md:grid-cols-4 gap-8">
                    {/**Pet Card 1 */} 
                    <div
                        className="md:col-span-2 group relative overflow-hidden bg-surface-container-lowest rounded-lg shadow-sm hover:shadow-xl transition-shadow duration-500">
                        <div className="aspect-[16/9] overflow-hidden">
                            <img alt="Corgi playing"
                                className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-700"
                                data-alt="Playful Pembroke Welsh Corgi running on a lush green lawn during a bright sunny afternoon with soft grass details"
                                src="https://lh3.googleusercontent.com/aida-public/AB6AXuDxywDzgrtPZdZCGOZA6HRtRh-LeFPtKVfDrUlcGxpY46A-PXAuLQpKeFMd1jct30ysJpvzcnubBPYmeWLL8rmK9ZjFxE95pvX0VQIObFsFu9irP8BbCcr5DUfag-GTY9DSRwYtizGhNPcbqMB3IeFnoTgy6SzkNvYNWKj74mHhZzHAMHh1YC0VyO2KWY9ETSLVF6gfu9-pSzbCoXM-8rCd9eZxvFZg1mSR28cRILrAe_lsr1TgBymnwk1LyAAVXdPYjxNFsXQ5wxk" />
                        </div>
                        <div className="p-8">
                            <div className="flex justify-between items-center mb-4">
                                <h3 className="text-2xl font-bold">Bentley</h3>
                                <span
                                    className="px-4 py-1 bg-secondary-fixed text-on-secondary-fixed rounded-full text-xs font-bold">Corgi</span>
                            </div>
                            <p className="text-on-surface-variant mb-8 line-clamp-2">A energetic ball of sunshine who loves
                                morning walks and afternoon treats. Perfectly sized for urban living.</p>
                            <button
                                className="w-full py-4 bg-primary text-on-primary rounded-xl font-bold transition-all satin-hover">View
                                Profile</button>
                        </div>
                    </div>
                    {/**Pet Card 2 */} 
                    <div
                        className="group relative overflow-hidden bg-surface-container-lowest rounded-lg shadow-sm hover:shadow-xl transition-shadow duration-500">
                        <div className="aspect-[4/5] overflow-hidden">
                            <img alt="White cat"
                                className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-700"
                                data-alt="Elegant white long-haired cat sitting on a grey velvet sofa in a minimalist modern living room with soft lighting"
                                src="https://lh3.googleusercontent.com/aida-public/AB6AXuCS3GvN3d5LV7d68-RtCFZRY9HWwAf5i3SK2nctPkcHPB9QSUcO_cMDUcNfC87f5aicnNJdVXdpBZWRfmZ9arKpex7zyEgnrtTF-SvmogsN5qB5WPi5v3l5fA727_nawhSkYLIP7S_tYpHzkClltfzgDHey0jvwapgIqFzSn8sVeS8jnykIFlcqH-hM3nW8VJELtstaiiDQKYNkAEndpDkC34CS91sPg7J5I6_holI7jWlhjoZ6YzbsNHsnFuR8VxV7kASCuoWyJmM" />
                        </div>
                        <div className="p-6">
                            <h3 className="text-xl font-bold mb-2">Luna</h3>
                            <p className="text-sm text-on-surface-variant mb-6">Persian Mix • 2 years</p>
                            <button
                                className="w-full py-3 bg-surface-container text-primary rounded-xl font-bold hover:bg-secondary-fixed transition-colors">View
                                Profile</button>
                        </div>
                    </div>
                    {/**Pet Card 3 */} 
                    <div
                        className="group relative overflow-hidden bg-surface-container-lowest rounded-lg shadow-sm hover:shadow-xl transition-shadow duration-500">
                        <div className="aspect-[4/5] overflow-hidden">
                            <img alt="Small dog"
                                className="w-full h-full object-cover group-hover:scale-105 transition-transform duration-700"
                                data-alt="Small fluffy poodle mix wearing a yellow bandana sitting outdoors on a clean sidewalk at sunset"
                                src="https://lh3.googleusercontent.com/aida-public/AB6AXuCRXHvpT-dVLb4Ngk4A_EBM2JvO1yLxfm-3o1GFgcfpprl5Hckb2xrz_-4CsZXbFslj2k9v6-Dt9nfhNrVvEaskWYBcD4FEG9B05td8WJ7IhLUsWItxWnlutzTVIstX2M_JkCrKaQzyyVWMUOumRat7RhG2gSnjQKONTboqds6ZToR6t8VX1JRhK6CmIphj8ZQ1clj1K2Vr1e2laIaMU9Ef92-3rmmCz42T3I8TpTNJqIOt4CXolmqd4cQnRtF7W7CW4WLB6tmMJCE" />
                        </div>
                        <div className="p-6">
                            <h3 className="text-xl font-bold mb-2">Oliver</h3>
                            <p className="text-sm text-on-surface-variant mb-6">Toy Poodle • 1 year</p>
                            <button
                                className="w-full py-3 bg-surface-container text-primary rounded-xl font-bold hover:bg-secondary-fixed transition-colors">View
                                Profile</button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
  )
}

export default FeaturedPetsSection
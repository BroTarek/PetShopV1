import React from 'react'
import ImageCarousel from './(Components)/ImageCarousel'
import ProfileSummary from './(Components)/ProfileSummary'
import AdoptionRequestsBox from './(Components)/AdoptionRequestsBox'
import RelatedPetsGrid from './(Components)/RelatedPetsGrid'
import EditorialDetailsSection from './(Components)/EditorialDetailsSection'

const page = () => {
    return (
        <>

            <main className="pt-32 pb-20 max-w-screen-2xl mx-auto px-6 md:px-12">
                {/* <!-- Hero Section: Instagram-style Image Carousel Centerpiece --> */}
                <div className="grid grid-cols-1 md:grid-cols-12 gap-6 lg:gap-8 mb-20">
                    <ImageCarousel />
                    <ProfileSummary />
                </div>
                {/* <!-- Editorial Details Section --> */}

                <EditorialDetailsSection />
                {/* <!-- Interest List Section --> */}
                <section className="mb-32">
                    <div className="grid grid-cols-1 lg:grid-cols-12 gap-8 items-stretch">
                        <div className="lg:col-span-8 flex flex-col justify-center">
                            <h2 className="text-4xl font-extrabold tracking-tighter mb-4 font-headline">Join Beau's World</h2>
                            <p className="text-on-surface-variant text-lg max-w-xl">We carefully vet every applicant to ensure Beau
                                finds the perfect forever home. Check the current interest levels below.</p>
                        </div>
                        {/* <!-- Adoption Requests Box --> */}
                        <AdoptionRequestsBox />
                    </div>
                </section>
                {/* <!-- Related Pets Grid --> */}

                <RelatedPetsGrid />
            </main>
        </>
    )
}

export default page
import React from 'react'
import ActivitiesSection from './(Components)/ActivitiesSection'
import ProfileStats from '@/app/Posts/(Components)/ProfileStats'


const page = () => {
    return (
        <main className="pt-32 pb-20 max-w-screen-2xl mx-auto px-6 md:px-12 grid grid-cols-1 md:grid-cols-12 gap-12 lg:gap-16">
            {/* <!-- Left Sidebar: Profile Stats --> */}
            <div className="md:col-span-4 lg:col-span-3">
                <ProfileStats/>
            </div>

            {/* <!-- Center Column: The Feed --> */}
            <div className="md:col-span-8 lg:col-span-9">
                <ActivitiesSection/>
            </div>
        </main>
    )
}

export default page
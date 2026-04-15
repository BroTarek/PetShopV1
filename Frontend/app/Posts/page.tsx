import React from 'react'
import ProfileStats from './(Components)/ProfileStats'
import CreatePostAnchor from './(Components)/CreatePostAnchor'
import Post from './(Components)/Post'

const page = () => {
    return (
        <>
            <main className="pt-24 pb-12 max-w-7xl mx-auto px-6 grid grid-cols-1 md:grid-cols-12 gap-8">
                {/* <!-- Left Sidebar: Profile Stats --> */}
                   <ProfileStats/>
                {/* <!-- Center Column: The Feed --> */}
                <section className="md:col-span-6 space-y-8">
                    {/* <!-- Create Post Anchor --> */}
                     <CreatePostAnchor/>
                    {/* <!-- Feed Posts --> */}
                    {Array(5).map((i)=>(<Post key={i}/>))}
                </section>

            </main>
        </>
    )
}

export default page
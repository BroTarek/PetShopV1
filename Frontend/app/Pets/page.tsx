import React from 'react'
import HeroSection from './(Components)/HeroSection'
import Pagination from './(Components)/Pagination'
import PetCard from './(Components)/PetCard';
import PetGrid from './(Components)/PetGrid';
import SidebarFilters from './(Components)/SidebarFilters';

interface Pet {
    name: string;
    image: {
        alt: string;
        url: string;
    };
    tag: string;
    age: number;
    gender: string;
    size: string;
    status: string;
    description: string;
}

const page = () => {

    const pets: Pet[] = [

        {
            name: "Beau",
            image: {
                alt: "Close-up portrait of a happy Golden Retriever puppy with soft golden fur in a sun-drenched outdoor park setting",
                url: "https://lh3.googleusercontent.com/aida-public/AB6AXuBhWPOBeeH0MC2LA42hf67euSh2ZD32zKb1rqhjbG1PaGfOHNtykS8Ep0tsHWs8bSwMLPfgGES8q-wzA0OQGpxxKU0RIhk7xmylBHL1Hba4JjzdB9E0Gb0dIvW_CeujNwkEgCyL7JlwGEe9brfTuomDKHwoIEvazZE4KSGMSgcHRsxyvKnNVU8t_eEFND4kgdDwHUZD2EG4sJIUyZolnP3kXGLil2LDa932Md6DlJcY2Jb35MvCx3nhHDihoeGesZ1IygnxrqUJa-E"
            },
            tag: "Golden Retriever",
            age: 2,
            gender: "Male",
            size: " Large",
            status: "Unadopted",
            description: "Beau is an adventurous spirit who loves long weekend hikes and cozy fireplace evenings."
        },
        {
            name: "Cooper",
            image: {
                alt: "Sprightly Beagle dog running in a wide grassy field, tongue out, ears flapping, bright daylight atmosphere",
                url: "https://lh3.googleusercontent.com/aida-public/AB6AXuAX-saBEn6jite_qnBehlUXhv2N7ahr1MWp2gzYY9yyxrrkHOCa0HaXXV5EtQTLRtdTu1lG6KpXbduVa1JUwCu6Vk0X1Inn4l905fgYAbiA7RlnJ_gw4qk11hY9lc6qnd_CZeHBESY3sG0pP88hAwhqKj03assINn3qPZkb6XJMVRNoygH-qToB0pjZP4EqHedaCHIf6kSRoaMu-_72a1ywTxYz-sVBl0wyXWT8XeOxJ_-I9d1_MvM2gnmL-LiB4mrbRAeyed5OOCE"
            },
            tag: "Beagle",
            age: 1 ,
            gender: "Male",
            size: "Medium",
            status: "In Stock",
            description: "Cooper is high energy and full of love. Perfect for an active family with children."
        },
        {
            name: "Willow",
            image: {
                alt: "Portrait of a young woman hugging a large brown mixed-breed dog, natural lighting, expressive joy, indoor home setting",
                url: "https://lh3.googleusercontent.com/aida-public/AB6AXuCRIplvj1rmAhTX4Z2zHrhhsGwWncmLTlCT0hte5EV5WjBjskfnTtTR_y-X-Mk51JKnd0R1eLHhk2F8kve5Suw0_QGgYzRjnHaeCYAUx9KRlQB87S_DGPUGTAp1NZjNn-BzE9e9VNjKfS0YivgCerUsHQDyBXcEMbj4d5mRJ0WjNul5pVluAtdf-hVBuPlirs_3bcF9Z-NSi2kdHTR8co7buaXpZ8ilTHbG00zMlhfWdYdrgS1S9ANUUkWcjecycocC4fIGEVig5wo"
            },
            tag: "Mixed Breed",
            age: 3,
            gender: "Female",
            size: "Large",
            status: "In Stock",
            description: "Willow is highly intelligent and responds well to training. A loyal companion for life."
        },
        {
            name: "Oscar",
            image: {
                alt: "Cute Dachshund puppy standing on a minimalist wooden floor, soft focus background, clean modern aesthetic",
                url: "https://lh3.googleusercontent.com/aida-public/AB6AXuDW13No5xlMtpdm8-PhiUvvus1dCMkcEHERsIZAwzm1VAYidT3vi_r4yy5SnyhDlj5nU-pTFyILtDyEJzBU7dq8WRbHzcFq7Ic38o_GPAlMm6CN0euY18d9JrrVQ2AmI19wkeRIS6FE3J3_-FIPKpomjh-nrD8r68BZJPBX1dHK9bgaSlnQBP4Kfc7KI8tz5JG02PkPvaZ_MN8ecBxxjBnQEMHLcP9l-KnU0C26cFuoQC6BIvgcVV4cA8an03NHCEoHp9fr-kXrK1A"
            },
            tag: "Dachshund",
            age: 6,
            gender: "Male",
            size: "Small",
            status: "In Stock",
            description: "Oscar is tiny but has a big personality. He loves squeaky toys and burrowing in blankets."
        },
        {
            name: "Pearl",
            image: {
                alt: "Pure white longhair cat with different colored eyes sitting elegantly on a bright windowsill, soft bokeh background",
                url: "https://lh3.googleusercontent.com/aida-public/AB6AXuCI-BSz3kVOu49HwrE3MN9odn-cCvXICUyM886hbF_HFOVqjvU6SR3isDTmxPzSQ36OLqslZL2-CdcDluafUjbBoqk9C9oLvNfdcaaRRe9NkhOB8Tik_SN6Z9eGeZ8g79sZtMpcKsWOHI_r-b3bclqXWFJkRfIFFTMxf5XkQP-nNflovJLx4JJSl0QMcn88rTtS1RDJ4ty_zxoSGTJKVSMvzpJoblXuVb2Sp-_hjTFZ37j75mXaV81EpoyYzBFKA0n6DIhauPzBbY4"
            },
            tag: "Angora",
            age: 2,
            gender: "Female",
            size: "Small",
            status: "In Stock",
            description: "Pearl is as elegant as she is affectionate. She requires regular grooming and lots of love."
        },
        {
            name: "Luna",
            image: {
                alt: "Portrait of a majestic grey tabby cat with striking green eyes sitting gracefully on a velvet armchair in soft lighting",
                url: "https://lh3.googleusercontent.com/aida-public/AB6AXuDuJgfEKU2llvqiFG5xsmbKS_InPeSJVBX6eebMcN-wN_Kk58Mv7fpU0VFh6mXqTn6BUmzIb9Z7E0ctbd1PmJaBI5HvLbZWQ4WFkIGM4VxwQOipju5sKtiXwUGZrj2CkzPkS-7uj2V_t3yN3kujaOrFoRqa5HdocvcEYespT5C69KrN9wJG1MeZIsdIX9DCnxOgkmWRH6LxHvYqMHZqeeAUOwZpC4hD-TtfV03cBIopNhBE_gn8wd-3Bga1JzRmwiHRH13hCh4xx6U"
            },
            tag: "Golden Retriever",
            age: 4,
            gender: "Female",
            size: "Small",
            status: "Unadopted",
            description: "Luna is a gentle soul looking for a quiet home. She enjoys sunlight and high-quality treats."
        }
    ];


    return (
        <>
            <main className="pt-32 pb-20 max-w-screen-2xl mx-auto px-6 md:px-12">
                <HeroSection />
                <div className="flex flex-col lg:flex-row gap-12">
                    <SidebarFilters/>
                    <PetGrid>
                        <div className="flex justify-between items-center mb-8">
                            <p className="text-sm text-on-surface-variant font-medium">Showing <span
                                className="text-primary font-bold">24 companions</span> nearby</p>
                            <div className="flex items-center gap-2">
                                <span className="text-xs font-bold uppercase text-on-surface-variant">Sort by:</span>
                                <select className="bg-transparent border-none text-sm font-bold focus:ring-0 cursor-pointer">
                                    <option>Newest Arrivals</option>
                                    <option>Distance</option>
                                    <option>Personality</option>
                                </select>
                            </div>
                        </div>
                        <div className="grid grid-cols-1 md:grid-cols-2 xl:grid-cols-3 gap-8">

                            {pets.map((pet, i) => (<PetCard Props={pet} />))}
                        </div>
                        <Pagination />
                    </PetGrid>
                </div>
            </main>
        </>
    )
}

export default page
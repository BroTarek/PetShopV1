import React from 'react'

const HeroSection = () => {
  return (
    <header className="mb-20 text-center md:text-left max-w-3xl">
            <span
                className="inline-block px-4 py-1.5 mb-6 text-xs font-bold tracking-widest uppercase bg-secondary-container text-on-secondary-container rounded-full">Available
                Now</span>
            <h1 className="text-6xl md:text-7xl font-extrabold tracking-tighter text-primary mb-6 leading-[0.9]">
                Find your <br /><span className="text-secondary italic font-medium">soul companion.</span>
            </h1>
            <p className="text-xl text-on-surface-variant leading-relaxed">
                A meticulously curated gallery of pets waiting for a home. We focus on ethical placement and lifetime
                matches.
            </p>
        </header>
  )
}

export default HeroSection
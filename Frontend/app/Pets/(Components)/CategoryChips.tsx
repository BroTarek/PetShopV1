import React from 'react'

const CategoryChips = () => {
    return (
        <>

            <section>
                <h4 className="text-xs font-bold uppercase tracking-widest text-on-surface-variant mb-4">Pet
                    Type</h4>
                <div className="flex flex-wrap gap-2">
                    <button
                        className="px-4 py-2 rounded-full text-sm font-semibold bg-primary text-on-primary">All</button>
                    <button
                        className="px-4 py-2 rounded-full text-sm font-semibold bg-surface-container-high text-on-surface-variant hover:bg-secondary-fixed transition-colors">Dogs</button>
                    <button
                        className="px-4 py-2 rounded-full text-sm font-semibold bg-surface-container-high text-on-surface-variant hover:bg-secondary-fixed transition-colors">Cats</button>
                    <button
                        className="px-4 py-2 rounded-full text-sm font-semibold bg-surface-container-high text-on-surface-variant hover:bg-secondary-fixed transition-colors">Birds</button>
                </div>
            </section>
        </>
    )
}

export default CategoryChips
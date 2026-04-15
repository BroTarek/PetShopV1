import React from 'react'
import AgeRange from './AgeRange'
import SizeSelection from './SizeSelection'
import CategoryChips from './CategoryChips'

const SidebarFilters = () => {
    return (
        <>
            <aside className="w-full lg:w-72 flex-shrink-0">
                <div className="sticky top-32 space-y-10">
                    <div>
                        <h3 className="font-bold text-lg mb-6 flex items-center gap-2">
                            <span className="material-symbols-outlined text-secondary">tune</span> Filters
                        </h3>
                        <div className="space-y-8">
                            <CategoryChips />
                            <SizeSelection />
                            <AgeRange />
                        </div>
                    </div>
                </div>
            </aside>
        </>
    )
}

export default SidebarFilters